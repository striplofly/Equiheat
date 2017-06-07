using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public VirtualJoyStick joyStick;
	  public float moveSpeed;
    public float initialTemp = 50.0f;
    public float transferHeat = 0.5f;
    public float relaunchFire = 3f;
    public GameObject bg;
    public Scrollbar playerBar;
    public Text playerText;

    static public bool isMoving;
    static public float currentTemp;


    private Vector3 moveDirection;
    private float xMin, xMax, yMin, yMax;
    private int maxTemp = 100;

    void Awake()
    {
        temp = pTemp;
        isMoving = true;
		    currentTemp = initialTemp;
    }

	void Start ()
    {
        SetTempBar();
        SetTempText();
    }
	
	void Update ()
    {
		PlayerMove ();
    }

	void PlayerMove (){
		moveDirection = joyStick.inputVector;

		if (moveDirection.magnitude != 0)
		{
			transform.localPosition += moveDirection * moveSpeed;

			//float clampX = Mathf.Clamp(transform.localPosition.x, xMin, xMax);
			//float clampY = Mathf.Clamp(transform.localPosition.y, yMin, yMax);
			//transform.localPosition = new Vector3(clampX, clampY, transform.localPosition.z);
		}
			
		//Debug.Log ("Player Move Values : " + moveDirection);
	}

	void OnCollisionStay2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Fire"))
        {
            FireController fire = new FireController();

            temp += fire.TempVal;
            SetTempBar();
            SetTempText();
        }

        if (collision.gameObject.CompareTag("Ice"))
        {
            FireController.isMoving = false;
            Invoke("RelaunchFireElement",relaunchFire);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Target")) {
		    	currentTemp -= transferHeat * Time.deltaTime;
		    	SetTempBar ();
			    SetTempText ();
	    	} 

        if (collision.gameObject.CompareTag("Fire"))
        {
            FireController fire = new FireController();

            temp += fire.TempVal * Time.deltaTime;
            SetTempBar();
            SetTempText();
        }

    }  

    void SetTempBar()
    {
        if(Mathf.RoundToInt(temp) != maxTemp)
            playerBar.size = temp / maxTemp;

    }

    void SetTempText()
    {
        if (Mathf.RoundToInt(temp) != maxTemp)
            playerText.text = temp.ToString("N0");
    }

    void RelaunchFireElement()
    {
        FireController.isMoving = true;

    }
}

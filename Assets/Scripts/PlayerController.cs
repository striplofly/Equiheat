using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public VirtualJoyStick joyStick;
	public float moveSpeed;
    public float initialTemp = 50.0f;
    public float transferHeat = 0.5f;
    public GameObject bg;
    public Scrollbar playerBar;
    public Text playerText;

	static public float currentTemp;

    private Vector3 moveDirection;
    private float xMin, xMax, yMin, yMax;
    private float maxTemp = 100f;

    void Awake()
    {
		currentTemp = initialTemp;
    }

	void Start ()
    {
        SetTempBar();
		SetTempText();

        // will change this later
        xMin = -8;
        xMax = 8;
        yMin = -5;
        yMax = 5;
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
			
		Debug.Log ("Player Move Values : " + moveDirection);
	}

	void OnCollisionStay2D(Collision2D collision)
    {
		//Debug.Log ("Collision detected");

		if (collision.gameObject.CompareTag ("Target")) {
			currentTemp -= transferHeat * Time.deltaTime;
			SetTempBar ();
			SetTempText ();
		} 

    }  

    void SetTempBar()
    {
		playerBar.size = currentTemp / maxTemp;
    }

    void SetTempText()
    {
		playerText.text = currentTemp.ToString("N0");
    }
}

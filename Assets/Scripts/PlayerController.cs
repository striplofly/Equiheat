using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public VirtualJoyStick joyStick;
    public float pTemp = 50.0f;
    public float moveSpeed = 5.0f;
    public float transferHeat = 0.5f;
    public GameObject bg;
    public Scrollbar playerBar;
    public Text playerText;


    static public float temp;

    private Vector3 moveDirection;
    private float xMin, xMax, yMin, yMax;
    private float maxTemp = 100f;

    void Awake()
    {
        temp = pTemp;
    }

	void Start ()
    {
        SetTempBar();
        SetTempText();
    }
	
	void Update ()
    {
        moveDirection = joyStick.inputVector;

        if(moveDirection.magnitude != 0)
            transform.localPosition += moveDirection * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fire"))
        {
            FireController fire = new FireController();

            temp += fire.TempVal;
            SetTempBar();
            SetTempText();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            temp -= transferHeat * Time.deltaTime;
            SetTempBar();
            SetTempText();
        }        
    }  

    void SetTempBar()
    {
        playerBar.size = temp / maxTemp;
    }

    void SetTempText()
    {
        playerText.text = temp.ToString("N0");
    }
}

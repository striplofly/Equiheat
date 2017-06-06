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

    static public bool isMoving;
    static public float temp;

    private Vector3 moveDirection;
    private float xMin, xMax, yMin, yMax;
    private int maxTemp = 100;

    void Awake()
    {
        temp = pTemp;
        isMoving = true;
    }

	void Start ()
    {
        SetTempBar();
        SetTempText();
    }
	
	void Update ()
    {
        moveDirection = joyStick.inputVector;

        if(moveDirection.magnitude != 0 && isMoving)
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

        if (collision.gameObject.CompareTag("Ice"))
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
}

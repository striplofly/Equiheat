using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public VirtualJoyStick joyStick;
    public float pTemp = 50.0f;
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float transferHeat = 0.5f;

    static public float temp;

    private Vector3 moveDirection;
    private float xMin, xMax, yMin, yMax;
    private Text playerTemp;

	void Start ()
    {
        temp = pTemp;
       // playerTemp = transform.GetChild(0).GetComponent<Text>();
        //playerTemp.text = temp.ToString();

        //Initialization of boundaries
        xMax = Screen.width - 50; // I used 50 because the size of player is 100*100
        xMin = 50;
        yMax = Screen.height - 50;
        yMin = 50;
    }
	
	void Update ()
    {
        moveDirection = joyStick.inputVector;

        if(moveDirection.magnitude != 0)
        {
            transform.localPosition += moveDirection * moveSpeed;
            //transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, xMin, xMax), Mathf.Clamp(transform.localPosition.y, yMin, yMax), 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            //Debug.Log("Collide with " + collision.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
            temp -= transferHeat * Time.deltaTime;       
            
    }  
}

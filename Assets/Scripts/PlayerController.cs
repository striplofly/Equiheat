using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public VirtualJoyStick joyStick;
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;

    private Vector3 moveDirection;
    private float xMin, xMax, yMin, yMax;

	void Start ()
    {
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
            transform.position += moveDirection * moveSpeed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), 0f);
        }
    }

    /*Vector3 UpdateJoyStickPos()
    {
        Vector3 direction = Vector3.zero;

        direction.x = joyStick.Horizontal();
        direction.z = joyStick.Vertical();

        if (direction.magnitude > 1)
            direction.Normalize();

        return direction;
    }

    void UpdatePlayerPos()
    {
        playerRigidBody.AddForce(moveVector * moveSpeed);
    }*/
}

using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{
    public int tempVal = 5;
    public float speed = 5f;
    public bool isHorizontal, isVertical, isMoving;
    public Transform player;

    private Vector3 moveLeft, moveRight, moveUp, moveDown;
    private Rigidbody2D rigidBody;
    private bool goLeft, goRight, goUp, goDown;

	void Start()
    {
        moveLeft = Vector2.left;
        moveRight = Vector2.right;
        moveUp = Vector2.up;
        moveDown = Vector2.down;

        rigidBody = GetComponent<Rigidbody2D>();

        goRight = true;
    }

	void Update ()
    {
        // horizontal   
        if (isHorizontal)
            MoveHorizontal();

        // vertical
        if (isVertical)
            MoveVertical();

        // free - follow player
        if (isMoving)
            MoveFree();
    }

    void MoveHorizontal()
    {
        if(goRight)
            transform.position += moveRight * speed * Time.deltaTime;

        if(goLeft)
            transform.position += moveLeft * speed * Time.deltaTime;
    }

    void MoveVertical()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 8), transform.position.z);
    }

    void MoveFree()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.localPosition, step);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(isHorizontal)
            {
                if (transform.localPosition.x > 0)
                    goLeft = true;

                if (transform.localPosition.x < 0)
                    goRight = true;
            }

            
        }
            
    }

    public int TempVal
    {
        get
        {
            return tempVal;
        }

        set
        {
            tempVal = value;
        }
    }


}

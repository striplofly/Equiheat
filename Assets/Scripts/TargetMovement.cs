using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {

	public GameController gameScript;
	public float moveSpeed;
	private Vector3 moveDirection;

	void Start () {
		moveDirection.Set (0.1f, 0.1f, 0f);
		//moveSpeed = moveSpeed * moveSpeed;
	}

	void Update () {
		
		if (!gameScript.isFinish) {
			Move ();
		}
	}
		
	void Move(){
		
		transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;
		//transform.Translate (moveDirection * moveSpeed * Time.deltaTime);								//This kinda works too.
		//Debug.Log ("Move Speed : " + moveSpeed);
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Arena"))
		{

		}
	}
}

using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {

	public GameController gameScript;
	public float moveSpeed;

	private Vector3 moveDirection;
	private Vector3 newDirection;
	private RaycastHit2D hit;
	private Ray2D ray;

	private bool up;
	private bool right;
	private bool arenaCollide;

	void Start () {
		//moveDirection.Set (0.1f, 0.1f, 0f);
		//moveSpeed = moveSpeed * moveSpeed;
		up = true;
		right = true;
		arenaCollide = false;
	}

	void Update () {
		
		if (!gameScript.isFinish) {
			
			MoveNew ();
			//Debug.Log ("Current Movement : " + moveDirection);
			Debug.Log ("Arena Collide? : " + arenaCollide);
		}
	}
		
	void Move(){

		transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;
		//transform.Translate (moveDirection * moveSpeed * Time.deltaTime);								//This kinda works too.
		//Debug.Log ("Move Speed : " + moveSpeed);
	}

	void MoveNew(){

		if (up) {
			
			//moveDirection = transform.up;
			moveDirection = Vector3.up;
			transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;

			if (arenaCollide) {
				up = false;
				Debug.Log ("Arena collide : " + arenaCollide);
			}
			arenaCollide = false;
		}

		else if (!up) {
			//moveDirection = -transform.up;
			moveDirection = Vector3.down;
			transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;

			if (arenaCollide) {
				up = true;
				Debug.Log ("Arena collide : " + arenaCollide);
			}
			arenaCollide = false;
		}
	}




	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Arena"))
		{
			arenaCollide = true;
		}
	}
}

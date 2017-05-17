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
			
			Move ();
			//Debug.Log ("Current Movement : " + moveDirection);
			Debug.Log ("Beginning Movement. Up flag : " + up);
		}
	}
		



	void Move(){
		
		if (up) {
			
			moveDirection = Vector3.up;
			transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;
		}

		if (!up) {
			moveDirection = Vector3.down;
			transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;
		}

		if (right) {

			moveDirection = Vector3.right;
			transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;
		}

		if (!right) {

			moveDirection = Vector3.left;
			transform.localPosition += moveDirection * moveSpeed * Time.deltaTime;
		}
	}



	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Arena"))
		{
			arenaCollide = true;
		}

		if(collision.gameObject.CompareTag("ArenaVertical")){

			if (up) {
				up = false;
				Debug.Log ("Direction changed, projectile now moving downwards.");
			}

			else if (!up) {
				up = true;
				Debug.Log ("Direction changed, projectile now moving upwards.");
			}
		}

		if(collision.gameObject.CompareTag("ArenaSides")){

			if (right) {
				right = false;
				Debug.Log ("Direction changed, projectile now moving left.");
			}

			else if (!right) {
				right = true;
				Debug.Log ("Direction changed, projectile now moving right.");
			}
		}
	}
}

/*
void MoveOld(){

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
*/
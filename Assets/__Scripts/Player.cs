using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float inputDirection; // X
	private float verticalVelocity; // Y

	private float speed = 5.0f;
	private float gravity = 30.0f;
	private float jumpForce = 10.0f;
	private bool secondJumpAvail = false; 

	private Vector3 moveVector;
	private Vector3 lastMotion;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = Vector3.zero;
		inputDirection = Input.GetAxis("Horizontal") * speed;

		if (controller.isGrounded) {
			verticalVelocity = 0;

			if (Input.GetKeyDown (KeyCode.Space)) {
				verticalVelocity = jumpForce;
				secondJumpAvail = true;
			}
			moveVector.x = inputDirection;
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				if(secondJumpAvail) {
					verticalVelocity = jumpForce;
					secondJumpAvail = false;
				}
			}
			verticalVelocity -= gravity * Time.deltaTime;
			moveVector.x = lastMotion.x;
		}


		moveVector.y = verticalVelocity;

		controller.Move (moveVector * Time.deltaTime);
		lastMotion = moveVector;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit) {
		if (controller.collisionFlags == CollisionFlags.Sides) {
			if(Input.GetKeyDown(KeyCode.Space)) {
				Debug.DrawRay(hit.point, hit.normal, Color.red, 2.0f);
				moveVector = hit.normal * speed;
				moveVector.y = jumpForce;
				secondJumpAvail = true;
			}

			//Collectibles
			switch(hit.gameObject.tag) {
			case "Coin":
				Destroy(hit.gameObject);
				break;
			default:
				break;
			}
		}
	}
}


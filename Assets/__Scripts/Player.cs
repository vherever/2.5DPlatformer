using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float inputDirection; // X
	private float verticalVelocity; // Y

	private float speed = 5.0f;
	private float gravity = 30.0f;
	private bool secondJumpAvail = false; 

	private Vector3 moveVector;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		inputDirection = Input.GetAxis("Horizontal") * speed;

		if (controller.isGrounded) {
			verticalVelocity = 0;

			if (Input.GetKeyDown (KeyCode.Space)) {
				verticalVelocity = 10;
				secondJumpAvail = true;
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				if(secondJumpAvail) {
					verticalVelocity = 10;
					secondJumpAvail = false;
				}
			}
			verticalVelocity -= gravity * Time.deltaTime;
		}

		moveVector = new Vector3 (inputDirection, verticalVelocity, 0);
		controller.Move (moveVector * Time.deltaTime);
	}
}

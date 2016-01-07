using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float inputDirection;
	private Vector3 moveVector;
	private CharacterController controller;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		inputDirection = Input.GetAxis("Horizontal");
		moveVector = new Vector3 (inputDirection, 0, 0);
		controller.Move (moveVector);
	}
}

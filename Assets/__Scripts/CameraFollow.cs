using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform lookAt;
	private Vector3 offset = new Vector3(0.0f, 1.0f, -8.0f);
	// Use this for initialization
	private void Start () {

	}

	private void LateUpdate() {
		transform.position = lookAt.transform.position + offset;
	}

}

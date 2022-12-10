using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public float mouseSensitivity = 50f;
	public Transform playerBody;

	float xRotation = 0f;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update() {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 0.05f;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 0.05f;
		
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
}

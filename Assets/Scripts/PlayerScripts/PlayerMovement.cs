using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameObject playerBody;
	public CharacterController controller;

	public float speed = 8f;
	public float gravity = -20f;
	public float jumpHeight = 2f;

	public float groundDistance = 0.4f;
	public Transform groundCheck;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

	void Update() {
		if (playerBody.transform.position.y < -1f) {
			FindObjectOfType<Manager>().EndLoss();
		}
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y < 0) velocity.y = -2f;

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		// forward
		Vector3 vec = transform.right * x + transform.forward * z;
		controller.Move(vec * speed * Time.deltaTime);
		// jump
		if (Input.GetButtonDown("Jump") && isGrounded) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		// falling
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}

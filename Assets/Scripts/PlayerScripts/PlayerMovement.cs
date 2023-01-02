using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public CharacterController controller;

	public float speed = 8f;
	public float gravity = -20f;
	public float jumpHeight = 2f;

	public float groundDistance = 1;
	public Transform groundCheck;
	public LayerMask ignoreMask;

	Vector3 velocity;
	//bool isGrounded;

	void start()
    {

    }
	void Update() {
		//if (isGrounded() && velocity.y < 0) velocity.y = -2f;
		if (isGrounded())
		{
			gravity = -20f;
			velocity.y = 0f;	
		}
        else
        {
			gravity += gravity * 0.001f;
			velocity.y += gravity * Time.deltaTime;
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		// forward
		Vector3 vec = transform.right * x + transform.forward * z;
		controller.Move(vec * speed * Time.deltaTime);
		// jump
		if (Input.GetButtonDown("Jump") && isGrounded()) {
			velocity.y = jumpHeight;
		}
		// falling
		
		controller.Move(velocity * Time.deltaTime);
	}
	public bool isGrounded()
    {
		RaycastHit hit;

		//return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		//Note : ignores a mask instead of only looking for it. 
		return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),out hit, groundDistance, ~ignoreMask);
	}
}

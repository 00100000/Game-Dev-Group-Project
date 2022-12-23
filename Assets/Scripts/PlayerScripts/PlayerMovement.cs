using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour {
	public CharacterController controller;

	public float speed = 8f;
	public float gravity = -20f;
	public float jumpHeight = 2f;

	public float groundDistance = 1;
	public Transform groundCheck;
	public LayerMask groundMask;

	private int points = 0;

	public TextMeshProUGUI text;

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
			velocity.y = -2f;	
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
		/*
		if (Input.GetButtonDown("Jump") && isGrounded()) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		// falling
		
		controller.Move(velocity * Time.deltaTime); */
	}
	public bool isGrounded()
    {
		//change this
		//return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		bool rc = Physics.Raycast(groundCheck.position, new Vector3(0, -groundDistance, 0), groundMask);
		Debug.Log(rc);

		return rc;
	}
    private void OnCollisionEnter(Collision collision)
    {
		points++;
		text.SetText(points + " points");
	}

	/*
    private void OnCollisionExit(Collision collision)
    {
		if (collision.gameObject.CompareTag("Ground"))
			isG = false;
    }
	*/
}

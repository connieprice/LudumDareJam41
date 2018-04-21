using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float movementSpeed = 6.0F;
	public float lookSpeed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float airDeaccelerate = 0.2F;

	public float gravity = 9.81F;

	private Vector3 moveDirection = Vector3.zero;

	private Transform firstpersonCamera;
	private CharacterController controller;

	void Start () {
		Screen.lockCursor = true;

		firstpersonCamera = transform.Find("FirstPersonCharacter");
		controller = GetComponent<CharacterController>();

		if (isLocalPlayer) {
			firstpersonCamera.gameObject.SetActive(true);
		}
	}
	
	void FixedUpdate () {
		if (!isLocalPlayer) {
			return;
		}

		if ( controller.isGrounded ) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= movementSpeed;

			if( Input.GetButton("Jump") ) {
				moveDirection.y = jumpSpeed;
			}
		} else {
			moveDirection.x -= airDeaccelerate * Time.deltaTime;
			moveDirection.z -= airDeaccelerate * Time.deltaTime;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		float rotation = Input.GetAxis("Mouse X") * lookSpeed;
		float vertical_rotation = -Input.GetAxis("Mouse Y") * lookSpeed;

		rotation *= Time.deltaTime;
		vertical_rotation *= Time.deltaTime;

		transform.Rotate(0, rotation, 0);
		firstpersonCamera.Rotate(vertical_rotation, 0, 0);
	}

}

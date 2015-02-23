using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

	// Movement
	public float forwardSpeed = 5f;
	public float rotationSpeed = 5f;

	private bool IsWalking = false;

	//General
	private Rigidbody playerRigidbody;
	private CharacterController characterController;
	
	// Use this for initialization
	void Awake() {
		this.playerRigidbody = GetComponent<Rigidbody>();
		this.characterController = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		this.Move();
		this.Rotate();
	}
 
	private void Move() {
		if(this.characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
			this.characterController.Move(Vector3.up);
		}
	
		Vector3 forward = this.transform.TransformDirection(Vector3.forward);
		float speed = this.forwardSpeed * Input.GetAxis("Vertical");
	
		this.characterController.SimpleMove(forward * speed);
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S)) {
			this.IsWalking = true;
		} else {
			this.IsWalking = false;
		} 
		

		Animator tmp= this.GetComponent<Animator>();
		tmp.SetBool ("IsWalking", this.IsWalking);
	}
	
	private void Rotate() {
		this.transform.Rotate(0, Input.GetAxis("Horizontal") * this.rotationSpeed, 0);
	}
}

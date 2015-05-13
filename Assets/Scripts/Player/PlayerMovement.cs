using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

	// Movement
	public float forwardSpeed = 5f;
	public float forwardSpeedMax = 7f;
	public float rotationSpeed = 5f;
	private float start_stamina = 100f;
	private float current_stamina;
	public float stamina_loss = 5;
	public Slider staminaSlider;

	private bool IsWalking = false;

	//General
	//private Rigidbody playerRigidbody;
	private CharacterController characterController;
	
	// Use this for initialization
	void Awake() {
		//Stamina init
		this.current_stamina = this.start_stamina;
		this.staminaSlider.value = this.current_stamina;

		//this.playerRigidbody = GetComponent<Rigidbody>();
		this.characterController = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		this.Move();
		this.Rotate();
	}
 
	private void Move() {
		if(this.characterController.isGrounded && Input.GetButtonDown("Jump")) {
			this.characterController.Move(Vector3.up);
		}
		//press shift to sprint

		if(Input.GetButton("Sprint") && this.current_stamina > 0) {
			if(forwardSpeed < forwardSpeedMax)
				forwardSpeed += 0.1f;
			current_stamina -= stamina_loss * Time.deltaTime;
		}
		//release shift to stop spriniting
		else {
			forwardSpeed = 5f;
			if(current_stamina < start_stamina)
				current_stamina += stamina_loss * Time.deltaTime;
		}
		this.staminaSlider.value = current_stamina;
		Debug.Log("stamina: " + current_stamina);
		Vector3 forward = this.transform.TransformDirection(Vector3.forward);
		float speed = this.forwardSpeed * Input.GetAxis("Vertical");
	
		this.characterController.SimpleMove(forward * speed);
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
			this.IsWalking = true;
		} else {
			this.IsWalking = false;
		} 
		

		Animator tmp = this.GetComponent<Animator>();
		tmp.SetBool("IsWalking", this.IsWalking);
	}
	
	private void Rotate() {
		this.transform.Rotate(0, Input.GetAxis("Horizontal") * this.rotationSpeed, 0);
	}
}

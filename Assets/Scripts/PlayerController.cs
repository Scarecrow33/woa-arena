using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

 // Attributes
 private float start_health = 100f;
 private float current_health;
 public Slider healthSlider;
 public AudioClip deathClip;
 private bool dead_flag;

 // General
 private PlayerInventory inventory;
 
 void Awake () {
	//Health init
	this.current_health = this.start_health;
	this.healthSlider.value = this.start_health;
	this.dead_flag = false;
		
	// General
	this.inventory = this.gameObject.GetComponent<PlayerInventory>();
 }

 void FixedUpdate () {
	if (Input.GetKeyDown(KeyCode.K)) {
	 this.damage(5f); 
	 if (this.dead_flag) {
		this.gameObject.SetActive(false);
	 }
	}
	/*
	if (this.GetComponent<PlayerInventory>().GetSize() > 0) {
	 GameObject right_hand = GameObject.Find("/Player/WoA_Man/python/hips/spine/chest/clavicle.R/upper_arm.R/forearm.R/hand.R");
	 Debug.Log(right_hand);
	 GameObject sword = this.inventory.GetItem(0);
	 //GameObject.Instantiate(sword);
	 sword.transform.parent = right_hand.transform; //Parenting this item to the hand bone position
	 sword.transform.localPosition = new Vector3(0, 0, 0); // centering the sword handle
	 sword.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
	 sword.transform.localRotation = Quaternion.Euler(270, 0, 0); //and rotate the sword accordingly
	 this.inventory.RemoveItem(0);
	}*/
 }

 private void damage (float dmg) {
	this.current_health -= dmg;
	this.healthSlider.value = this.current_health;
	if (this.current_health <= 0) {
	 this.dead_flag = true;
	}
 }	
}

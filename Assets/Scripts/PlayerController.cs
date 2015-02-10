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
 
	void Awake() {
		//Health init
		this.current_health = this.start_health;
		this.healthSlider.value = this.start_health;
		this.dead_flag = false;
		
		// General
		this.inventory = this.gameObject.GetComponent<PlayerInventory>();
	}

	void FixedUpdate() {
		if(Input.GetKeyDown(KeyCode.K)) {
			this.damage(5f); 
			if(this.dead_flag) {
				this.gameObject.SetActive(false);
			}
		}

		if(this.inventory.GetSize() > 0) {
			GameObject item = this.inventory.GetItem(0);
			GameObject attach_to = null;
			
			switch(item.name) {
				case "legio_helmet":
					attach_to = GameObject.Find("/Player/WoA_Man/python/hips/spine/chest/neck/head");
					item.transform.parent = attach_to.transform; //Parenting this item to the hand bone position
					item.transform.localPosition = new Vector3(0, .05f, 0); // centering the sword handle
					item.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
					item.transform.localRotation = Quaternion.Euler(270, 180, 0); //and rotate the sword accordingly
					break;
				
				case "legio_armor":
					attach_to = GameObject.Find("/Player/WoA_Man/python/hips/spine/chest");
					item.transform.parent = attach_to.transform; //Parenting this item to the hand bone position
					item.transform.localPosition = new Vector3(0, .1f, .03f); // centering the sword handle
					item.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
					item.transform.localRotation = Quaternion.Euler(270, 0, 0); //and rotate the sword accordingly
					break;
				
				case "weapon_gladius":
					GameObject right_hand = GameObject.Find("/Player/WoA_Man/python/hips/spine/chest/clavicle.R/upper_arm.R/forearm.R/hand.R/thumb.02.R");
					item.transform.parent = right_hand.transform; //Parenting this item to the hand bone position
					item.transform.localPosition = new Vector3(0, 0, 0); // centering the sword handle
					item.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
					item.transform.localRotation = Quaternion.Euler(0, 0, 0); //and rotate the sword accordingly
					break;
					
				case "weapon_scutum":
					GameObject left_hand = GameObject.Find("/Player/WoA_Man/python/hips/spine/chest/clavicle.L/upper_arm.L/forearm.L/hand.L");
					item.transform.parent = left_hand.transform; //Parenting this item to the hand bone position
					item.transform.localPosition = new Vector3(0, 0, -0.05f);
					item.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
					item.transform.localRotation = Quaternion.Euler(180, -90, 0); //and rotate the sword accordingly
					break;
					
				case "legio_tunica":
					GameObject tunica = GameObject.Find("/Player/WoA_Man/python/hips/spine/chest");
					item.transform.parent = tunica.transform; //Parenting this item to the hand bone position
					item.transform.localPosition = new Vector3(0, -.03f, .05f); // centering the sword handle
					item.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
					item.transform.localRotation = Quaternion.Euler(0, 90, 0); //and rotate the sword accordingly
					break;
			}			
			
			this.inventory.RemoveItem(0);
		}
	}

	private void damage(float dmg) {
		this.current_health -= dmg;
		this.healthSlider.value = this.current_health;
		if(this.current_health <= 0) {
			this.dead_flag = true;
		}
	}	
}

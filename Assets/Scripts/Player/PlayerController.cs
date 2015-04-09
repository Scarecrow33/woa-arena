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

	// Body
	private GameObject head;
	private GameObject chest;
	private GameObject hips;
	private GameObject hand_left;
	private GameObject hand_right;
	private GameObject feet_left;
	private GameObject feet_right;

	// General
	private PlayerInventory inventory;
 
	void Awake() {
		//Health init
		this.current_health = this.start_health;
		this.healthSlider.value = this.start_health;
		this.dead_flag = false;

		// Body
		string basePath = "/Player/RomanMan/roman_man/master/";
		this.head = GameObject.Find(basePath + "root/hips/spine/chest/neck/head");
		this.chest = GameObject.Find(basePath + "root/hips/spine/chest"); 
		this.hips = GameObject.Find(basePath + "root/hips");
		this.hand_right = GameObject.Find(basePath + "hand.ik.R");
		this.hand_left = GameObject.Find(basePath + "hand.ik.L");
		this.feet_left = GameObject.Find(basePath + "ankle.L");
		this.feet_right = GameObject.Find(basePath + "ankle.R");


		// General
		this.inventory = this.gameObject.GetComponent<PlayerInventory>();
		
		// UI Messages
		GameObject.Find("notification_box").GetComponent<Text>().text = "";
	}

	void FixedUpdate() {
		if(Input.GetKeyDown(KeyCode.K)) {
			this.damage(5f); 
			if(this.dead_flag) {
				AudioSource.PlayClipAtPoint(this.deathClip, transform.position);
				this.gameObject.SetActive(false);
			}
		}

		if(this.inventory.GetSize() > 0) {
			GameObject item = this.inventory.GetItem(0);
			
			switch(item.name) {
				case "legio_helmet":
					this.equip(item, this.head, new Vector3(0, .05f, 0), Quaternion.Euler(270, 180, 0));
					break;
				
				case "legio_armor":
					this.equip(item, this.chest, new Vector3(0, .01f, 0.3f), Quaternion.Euler(270, 0, 0));
					break;
				
				case "weapon_gladius":
					this.equip(item, this.hand_right);
					break;
					
				case "weapon_scutum":
					this.equip(item, this.hand_left, Vector3.zero, Quaternion.Euler(0, 90, 0));
					this.GetComponent<Animator>().SetBool("HasLeftItem", true);
					break;
					
				case "legio_tunica":
					this.equip(item, this.chest, new Vector3(0, -.03f, .05f), Quaternion.Euler(0, 90, 0));
					break;
				
				default: 
					this.GetComponent<Animator>().SetBool("HasLeftItem", false);
					break;
			}			
			
			this.inventory.RemoveItem(0);
		}
	}

	/// <summary>
	/// Damage the specified the player by the specified amount of damage.
	/// </summary>
	/// <param name="dmg">Damagevalue.</param>
	private void damage(float dmg) {
		this.current_health -= dmg;
		this.healthSlider.value = this.current_health;
		if(this.current_health < 0) {
			this.dead_flag = true;
		}
	}

	/// <summary>
	/// Attach the specified obj to the target with a specified position and rotation.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	/// <param name="pos">Position.</param>
	/// <param name="rot">Rotation.</param>
	private void equip(GameObject obj, GameObject target, Vector3 pos, Quaternion rot) {
		obj.transform.parent = target.transform; //Parenting this item to the hand bone position
		obj.transform.localPosition = pos; // centering the sword handle
		obj.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
		obj.transform.localRotation = rot; //and rotate the sword accordingly
	}

	/// <summary>
	/// Attach the specified obj to the target with a specified position.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	/// <param name="pos">Position.</param>
	private void equip(GameObject obj, GameObject target, Vector3 pos) {
		this.equip(obj, target, pos, Quaternion.identity);	
	}

	/// <summary>
	/// Attach the specified obj to the target with a specified rotation.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	/// <param name="rot">Rotation.</param>
	private void equip(GameObject obj, GameObject target, Quaternion rot){
		this.equip(obj, target, Vector3.zero, rot);	
	}

	/// <summary>
	/// Attach the specified obj to the target.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	private void equip(GameObject obj, GameObject target) {
		this.equip(obj, target, Vector3.zero, Quaternion.identity);	
	}

}

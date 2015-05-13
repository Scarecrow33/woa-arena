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
			GameObject obj = this.inventory.GetItem(0);
			Item item = obj.GetComponent<Item>();

			/*
			 * ToDo: Complete inventory equip mechanism
			if(item is Armor) {
				Armor armor = (Armor)item;
				GameObject slot = null;
				switch(armor.slot) {
					case ArmorType.Head:
						slot = this.head;
						break;
					case ArmorType.Shoulder:
						slot = null;
						break;
					case ArmorType.Chest:
						slot = this.chest;
						break;
					case ArmorType.Hip:
						slot = this.hips;
						break;
					case ArmorType.Legs:
						slot = null;
						break;
					case ArmorType.Feet:
						slot = this.feet_right;
						break;
					case ArmorType.Hands:
						slot = this.hand_right;
						break;
					default:
						break;
				}

				this.inventory.equip(obj, slot);
				
			} else if(item is Weapon) {
			
			} else {
			
			}*/

			switch(item.CanonicalName) {
				case "legio_helmet":
					this.inventory.equip(obj, this.head, new Vector3(0, .05f, 0), Quaternion.Euler(270, 180, 0));
					break;
				
				case "legio_armor":
					this.inventory.equip(obj, this.chest, new Vector3(0, .01f, 0.3f), Quaternion.Euler(270, 0, 0));
					break;
				
				case "weapon_gladius":
					this.inventory.equip(obj, this.hand_right);
					break;
					
				case "weapon_scutum":
					this.inventory.equip(obj, this.hand_left, Vector3.zero, Quaternion.Euler(0, 90, 0));
					this.GetComponent<Animator>().SetBool("HasLeftItem", true);
					break;
					
				case "legio_tunica":
					this.inventory.equip(obj, this.chest, new Vector3(0, -.03f, .05f), Quaternion.Euler(0, 90, 0));
					break;
				
				default: 
					break;
			}			
			
			//this.inventory.RemoveItem(0);
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
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Defines many generic attributes and methods for different types of armor.
/// Inherits from "Item".
/// </summary>
public class Armor : Item {

	protected ArmorType slot { get; set; }
	protected double armorValue { get; set; }

	public new void Awake() {
		base.Awake();
		this.armorValue = 0;
	}
	
	public override void OnTriggerStay(Collider other) {
		
		this.notificationBox.text = "Press 'E' to pick up " + this.CanonicalName + "!";
		
		if(Input.GetKeyDown("Interact")) {	
			if(other.gameObject == this.player) {
				AudioSource.PlayClipAtPoint(this.pickUpSound, this.player.transform.position);
				this.playerInventory.AddItem(this.gameObject);
				this.GetComponent<SphereCollider>().enabled = false;
				this.notificationBox.text = null;
			}
		}
	}
	
	public override void OnTriggerExit(Collider other) {
		this.notificationBox.text = null;
	}
	
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Defines many generic attributes and methods for different types of armor.
/// Inherits from "Item".
/// </summary>
[RequireComponent (typeof(SphereCollider))]
public class Armor : Item {

	public ArmorType slot { get; set; }
	public double armorValue { get; protected set; }
	

	public new void Awake() {
		base.Awake();
		this.armorValue = 0;
	}
	
	
	
	public override void OnTriggerStay(Collider other) {
		
		this.notificationBox.text = "Press 'E' to pick up " + this.CanonicalName + "!";
		
		if(Input.GetButtonDown("Interact")) {	
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
	
	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="Armor"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="Armor"/>.</returns>
	public override string ToString() {
		return string.Format("[Armor('" + this.CanonicalName + "'):" +
			"slot=" + this.slot +
			", rare=" + this.Rarety +
			", def=" + this.armorValue + "]");
	}
	
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Defines many generic attributes and methods for common weapon types. 
/// Inherits from "Item".
/// </summary>
[RequireComponent (typeof(SphereCollider))]
public class Weapon : Item {

	
	protected WeaponType RangeType { get; set; }

	protected float baseDamage { get; set; }
	protected float attackSpeed { get; set; }

	public new void Awake() {
		base.Awake();
		this.baseDamage = 7;
		this.attackSpeed = 1.0f;
	}

	public override void OnTriggerStay(Collider other) {
		
		this.notificationBox.text = "Press 'E' to pick up " + this.CanonicalName + "!";
		
		if(Input.GetKeyDown("Interaction")) {

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

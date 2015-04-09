using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(SphereCollider))]
public class Weapon : Item {

	protected RaretyType Rarety {get;set;}
	protected WeaponType RangeType {get;set;}

	protected float baseDamage {get;set;}
	protected float attackSpeed {get;set;}

	public AudioClip pickUpSound; // {get;set;}

	public void Awake(){
		base.Awake();
		this.baseDamage = 7;
		this.attackSpeed = 1.0f;
	}

	public override void OnTriggerStay(Collider other) {
		Text message_box = GameObject.Find("notification_box").GetComponent<Text>();
		
		message_box.text = "Press 'E' to pick up " + this.name + "!";
		
		if(Input.GetKeyDown(KeyCode.E)) {

			Debug.Log(Input.GetKeyDown(KeyCode.E));
			Debug.Log("N Player: " + (other.gameObject == this.player));

			if(other.gameObject == this.player) {
				AudioSource.PlayClipAtPoint(this.pickUpSound, this.player.transform.position);
				this.playerInventory.AddItem(this.gameObject);
				this.GetComponent<SphereCollider>().enabled = false;
				message_box.text = "";
			}
		}
	}

	public override void OnTriggerExit(Collider other) {
		GameObject.Find("notification_box").GetComponent<Text>().text = "";
	}
}

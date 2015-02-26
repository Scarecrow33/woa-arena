using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(SphereCollider))]
public class PickUpItem : MonoBehaviour {

	public AudioClip itemPickUpSound;
	public GameObject player;
	private PlayerInventory playerInventory;
	
	public void Awake() {
		//this.player = GameObject.FindWithTag("Player");
		this.playerInventory = this.player.GetComponent<PlayerInventory>();
	}

	public void OnTriggerStay(Collider other) {
		Text message_box = GameObject.Find("notification_box").GetComponent<Text>();

		message_box.text = "Press 'E' to pick up " + this.name + "!";

		if(Input.GetKeyDown(KeyCode.E)) {
			Debug.Log(Input.GetKeyDown(KeyCode.E));
			Debug.Log("Player: " + (other.gameObject == this.player));
			if(other.gameObject == this.player) {
				AudioSource.PlayClipAtPoint(this.itemPickUpSound, transform.position);
				//this.playerInventory.has_sword = true;
				this.playerInventory.AddItem(this.gameObject);
				this.GetComponent<SphereCollider>().enabled = false;
				//Destroy(this.gameObject);
				message_box.text = "";
			}
		}
	}
	
	public void OnTriggerExit(Collider other) {
		GameObject.Find("notification_box").GetComponent<Text>().text = "";
	}
	
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SphereCollider))]
public class PickUpItem : MonoBehaviour {

	public AudioClip itemPickUpSound;
	private GameObject player;
	private PlayerInventory playerInventory;
	
	public void Awake() {
		this.player = GameObject.FindWithTag("Player");
		this.playerInventory = this.player.GetComponent<PlayerInventory>();
	}

	public void OnTriggerStay(Collider other) {
		if(Input.GetKeyDown(KeyCode.E)) {
			if(other.gameObject == this.player) {
				AudioSource.PlayClipAtPoint(this.itemPickUpSound, transform.position);
				this.playerInventory.has_sword = true;
				this.playerInventory.AddItem(this.gameObject);
				//Destroy(this.gameObject);
			}
		}
	}
	
}

using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour {

	public string Name {get;set;}
	public GameObject player {get;set;}
	public PlayerInventory playerInventory {get;set;}

	public void Awake() {
		this.player = GameObject.FindWithTag("Player");
		this.playerInventory = this.player.GetComponent<PlayerInventory>();
	}

	public abstract void OnTriggerStay(Collider other);

	public abstract void OnTriggerExit(Collider other);

}

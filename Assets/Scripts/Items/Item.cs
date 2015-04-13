using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Defines all generic attributes and methods of a generic item.
/// </summary>
public abstract class Item : MonoBehaviour {

	/*
	 * External and "visual" attributes.
	 * Fallback values should be set insside the "Awake" function.
	 */
	public string CanonicalName;
	public RaretyType Rarety;
	public AudioClip pickUpSound;
	
	/*
	 * Internal attributes
	 */
	protected GameObject player { get; set; }
	protected PlayerInventory playerInventory { get; set; }
	protected Text notificationBox { get; set; }

	public void Awake() {
		this.player = GameObject.FindWithTag("Player");
		this.playerInventory = this.player.GetComponent<PlayerInventory>();
		this.notificationBox = GameObject.Find("notification_box").GetComponent<Text>();
		
		// Fallback values
		this.CanonicalName = this.name;
		this.Rarety = RaretyType.Normal;
	}

	public abstract void OnTriggerStay(Collider other);
	public abstract void OnTriggerExit(Collider other);

}

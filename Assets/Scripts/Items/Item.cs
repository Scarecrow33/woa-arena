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
	
	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="Item"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="Item"/>.</returns>
	public override string ToString() {
		return string.Format("[Item('" + this.CanonicalName + "'): " + this.Rarety + "]");
	}

	public abstract void OnTriggerStay(Collider other);
	public abstract void OnTriggerExit(Collider other);
}

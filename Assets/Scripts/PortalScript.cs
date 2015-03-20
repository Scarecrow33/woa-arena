using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PortalScript : MonoBehaviour {

	private GameObject player;
	public string target;

	// Use this for initialization
	void Awake() {
		this.player = GameObject.FindWithTag("Player");
		
	}
	
	public void OnTriggerStay(Collider other) {
		Text message_box = GameObject.Find("notification_box").GetComponent<Text>();
		
		message_box.text = "Press 'E' to use the " + this.name + " to teleport to " + target + "!";
		
		if(Input.GetKeyDown(KeyCode.E)) {
			if(other.gameObject == this.player) {
				Application.LoadLevel(target);
				message_box.text = "";
			}
		}
	}
	
	public void OnTriggerExit(Collider other) {
		GameObject.Find("notification_box").GetComponent<Text>().text = "";
	}
}

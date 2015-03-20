using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	private GameObject menu;

	void Awake() {
		this.menu = GameObject.FindGameObjectWithTag("Menu");
	}

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		
	}
}

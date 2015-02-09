using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	
 public bool has_sword;
 private List<GameObject> items;
	
 public void AddItem (GameObject obj) {
	this.items.Add(obj);
 }
	
 public void RemoveItem (GameObject obj) {
	this.items.Remove(obj);
 }
	
 public void RemoveItem (int index) {
	this.items[index] = null;
 }
	
 public GameObject GetItem (int index) {
	return this.items[index];
 }
	
 public int GetSize () {
	return this.items.Count;
 }
	
 public int GetIndexOf (GameObject obj) {
	return this.items.IndexOf(obj);
 }
	
 public void Awake () {
	this.items = new List<GameObject>();
 }
	
 public void FixedUpdate () {
	Debug.Log("Invenorysize: " + this.GetSize());
 }
	
}

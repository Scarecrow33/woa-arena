using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

	public bool DebugFlag = false;
	private List<GameObject> items;
	
	public void Awake() {
		this.items = new List<GameObject>();
	}
	
	public void FixedUpdate() {
		if(this.DebugFlag) {
			Debug.Log("Invenorysize: " + this.GetSize());
			
			foreach(GameObject item in items) {
				Debug.Log(item);
			}
		}
	}
	
	/// <summary>
	/// Adds the item.
	/// </summary>
	/// <param name="obj">Object.</param>
	public void AddItem(GameObject obj) {
		this.items.Reverse();
		this.items.Add(obj);
		this.items.Reverse();
	}
	
	/// <summary>
	/// Removes the item by the given object.
	/// </summary>
	/// <param name="obj">GameObject.</param>
	public void RemoveItem(GameObject obj) {
		this.items.Remove(obj);
	}
	
	/// <summary>
	/// Removes the item at the given index.
	/// </summary>
	/// <param name="index">Index.</param>
	public void RemoveItem(int index) {
		this.items.RemoveAt(index);
	}
	
	/// <summary>
	/// Gets the item by the given index.
	/// </summary>
	/// <returns>The item.</returns>
	/// <param name="index">Index of the item.</param>
	public GameObject GetItem(int index) {
		return this.items[index];
	}
	
	/// <summary>
	/// Gets the size of the inventory.
	/// </summary>
	/// <returns>The size.</returns>
	public int GetSize() {
		return this.items.Count;
	}
	
	/// <summary>
	/// Gets the index of a specific gameobject.
	/// </summary>
	/// <returns>The index of the given gameobject.</returns>
	/// <param name="obj">Object.</param>
	public int GetIndexOf(GameObject obj) {
		return this.items.IndexOf(obj);
	}
	
	/// <summary>
	/// Attach the specified obj to the target with a specified position and rotation.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	/// <param name="pos">Position.</param>
	/// <param name="rot">Rotation.</param>
	public void equip(GameObject obj, GameObject target, Vector3 pos, Quaternion rot) {
		obj.transform.parent = target.transform; //Parenting this item to the hand bone position
		obj.transform.localPosition = pos; // centering the sword handle
		obj.transform.localRotation = Quaternion.identity; //must point y local, so reset rotation
		obj.transform.localRotation = rot; //and rotate the sword accordingly
	}
	
	/// <summary>
	/// Attach the specified obj to the target with a specified position.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	/// <param name="pos">Position.</param>
	public void equip(GameObject obj, GameObject target, Vector3 pos) {
		this.equip(obj, target, pos, Quaternion.identity);	
	}
	
	/// <summary>
	/// Attach the specified obj to the target with a specified rotation.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	/// <param name="rot">Rotation.</param>
	public void equip(GameObject obj, GameObject target, Quaternion rot) {
		this.equip(obj, target, Vector3.zero, rot);	
	}
	
	/// <summary>
	/// Attach the specified obj to the target.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="target">Target.</param>
	public void equip(GameObject obj, GameObject target) {
		this.equip(obj, target, Vector3.zero, Quaternion.identity);	
	}
	
}

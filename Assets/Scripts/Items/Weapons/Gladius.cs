using UnityEngine;
using System.Collections;

public class Gladius : Weapon {

	public void Awake(){
		base.Awake();
		this.Rarety = RaretyType.Normal;
		this.RangeType = WeaponType.SingleHanded;
		Debug.Log(this.ToString());
	}
	
	
}

using UnityEngine;
using System.Collections;

public class Pilum : Weapon {

	public new void Awake() {
		base.Awake();
		
		this.CanonicalName = "Pilum";
		
		this.Rarety = RaretyType.Normal;
		this.RangeType = WeaponType.SingleHanded;
	}
}

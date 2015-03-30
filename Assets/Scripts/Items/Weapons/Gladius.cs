using UnityEngine;
using System.Collections;

public class Gladius : Weapon {

	public new void Awake() {
		base.Awake();
		this.Rarety = RaretyType.Normal;
		this.RangeType = WeaponType.SingleHanded;
	}
}

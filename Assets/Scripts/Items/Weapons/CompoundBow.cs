using UnityEngine;
using System.Collections;

public class CompoundBow : Weapon {

	public new void Awake() {
		base.Awake();
		this.attackSpeed = 0.7;
		this.baseDamage = 10;
		this.CanonicalName = "Compound Bow";
		this.RangeType = WeaponType.Ranged;
	}

}

using UnityEngine;
using System.Collections;

public class CompoundBow : Weapon {

	public GameObject projectile;

	public new void Awake() {
		base.Awake();
		this.attackSpeed = 0.7;
		this.baseDamage = 10;
		this.CanonicalName = "Compound Bow";
		this.RangeType = WeaponType.Ranged;
	}
	public void FixedUpdate() {
		if(this.projectile != null && Input.GetButtonDown("Fire1")) {
			Instantiate(projectile, transform.position, transform.rotation);
		}
	}
}

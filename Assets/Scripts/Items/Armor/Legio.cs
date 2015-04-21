using UnityEngine;
using System.Collections;

public class Legio : Armor {

	public new void Awake() {
		base.Awake();
		this.armorValue = 10;
		this.CanonicalName = "Legio";
		
		this.slot = ArmorType.Chest;
	}
}

using UnityEngine;
using System.Collections;

public class Sandals : Armor {

	public new void Awake() {
		base.Awake();
		this.armorValue = 10;
		this.CanonicalName = "Sandals";
		
		this.slot = ArmorType.Feet;
	}
}

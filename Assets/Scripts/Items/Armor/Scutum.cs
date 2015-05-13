using UnityEngine;
using System.Collections;

public class Scutum : Armor {

	public new void Awake() {
		base.Awake();
		this.armorValue = 7;
		this.CanonicalName = "Scutum";
		
		this.slot = ArmorType.Shield;
	}
}

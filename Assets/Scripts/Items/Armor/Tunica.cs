using UnityEngine;
using System.Collections;

public class Tunica : Armor {

	public new void Awake() {
		base.Awake();
		this.armorValue = 1;
		this.CanonicalName = "Tunica";
		
		this.slot = ArmorType.Chest;
	}
}

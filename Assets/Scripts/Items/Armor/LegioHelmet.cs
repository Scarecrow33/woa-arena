using UnityEngine;
using System.Collections;

public class Helmet : Armor {

	public new void Awake() {
		base.Awake();
		this.armorValue = 6;
		this.CanonicalName = "Legio Helmet";
		
		this.slot = ArmorType.Head;
	}
}

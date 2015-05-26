using UnityEngine;
using System.Collections;

public class CenturioHelmet : Armor {

	public new void Awake() {
		base.Awake();
		this.armorValue = 10;
		this.CanonicalName = "Centurio Helmet";
		
		this.slot = ArmorType.Head;
	}
}

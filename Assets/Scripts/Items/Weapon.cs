using UnityEngine;
using System.Collections;

public class Weapon : Item {

	private RaretyType Rarety {get;set;}

	private float baseDamage {get;set;}
	private float attackSpeed {get;set;}


	public Weapon(){
		this.baseDamage = 7;
		this.attackSpeed = 1.0f;
	}
}

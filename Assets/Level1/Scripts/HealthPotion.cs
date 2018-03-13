using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion")]
public class HealthPotion : Item {

	public int healAmount;

	public override void Use(){
		GameObject.FindGameObjectWithTag ("Health").GetComponent<PlayerHealthandExp>().currentHealth += healAmount;
		RemoveFromInventory ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipSlot;
	public SkinnedMeshRenderer mesh;
	public EquipmentMeshRegion[] coveredMeshRegions;

	public int weaponType = 0;
	public int armorModifier;
	public int damageModifier;

	//OverWritign the item method of use
	public override void Use(){

		Debug.Log ("Equipment: Use Method");
		EquipmentManager.instance.Equip (this);
		RemoveFromInventory ();
	}
}

public enum EquipmentSlot {Head, Chest, Legs,Feet, Weapon, Shield}
public enum EquipmentMeshRegion {Legs, Chest}

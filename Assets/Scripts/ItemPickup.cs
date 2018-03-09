using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;

	//press Fire3 to pick up item if room in inventory
	public override void Interact(){
		if(Input.GetButtonDown("Fire3")){
			
			Debug.Log("ItemPickup: Item name " + item.name);
			bool wasPickedUp = Inventory.instance.Add (item);

			if (wasPickedUp) {
				Destroy (gameObject);
			}
		}
	}

}

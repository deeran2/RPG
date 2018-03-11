using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;
	bool inside = false;
	//press Fire3 to pick up item if room in inventory
	void OnTriggerStay(Collider other){
		if (other.transform.tag == "Player")
			inside = true;
		
		if(Input.GetButtonDown("Fire3")){
			bool wasPickedUp = Inventory.instance.Add (item);

			if (wasPickedUp) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerExit(Collider other){
		inside = false;
	}
	public void OnGUI(){
		if (inside) {
		GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height - 50, 200, 35), "Press Shift to pick up " + item.name);
		}
	}

}

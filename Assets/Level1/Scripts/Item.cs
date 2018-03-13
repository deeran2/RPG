using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	public new string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;
	public GameObject respawn;
	 
	public virtual void Use(){

		Debug.Log ("Item: Use method");
		RemoveFromInventory ();
	}

	public void RemoveFromInventory(){
		
		Inventory.instance.Remove (this);
	}

}

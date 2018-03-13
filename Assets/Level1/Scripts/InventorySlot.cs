using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public Button removeButton;
	Item item;


	public void AddItem (Item newItem){

		item = newItem;
		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	public void ClearSlot (){

		item = null;
		icon.sprite = null;
		icon.enabled = false; 
		removeButton.interactable = false;
	}
	//Remove button removes from inventory instance

	public void OnRemoveButton(){
		Transform temp = GameObject.FindGameObjectWithTag ("Player").transform;
		Instantiate (item.respawn, temp.position, temp.rotation);
		Inventory.instance.Remove (item);
	}

	//Method on item object
	public void UseItem(){

		if(item != null){
			item.Use();
		}
	}
}

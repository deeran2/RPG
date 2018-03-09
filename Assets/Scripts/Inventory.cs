using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	void Awake(){

		if (instance != null) {

			Destroy (gameObject);
			return;
		}
		instance = this;
	}
	#endregion

	public delegate void OnItemChanged ();
	public OnItemChanged onItemChangedCallBack;

	public int space = 12;

	public List<Item> items = new List<Item> ();

	//adds item to instance list and returns if their is room
	public bool Add(Item item){

		if (!item.isDefaultItem) {

			if (items.Count >= space) {
				
				//Put code here to have itemicon apear at cursor
				Debug.Log ("Not enough space");
				return false;
			}
			items.Add (item);
			if (onItemChangedCallBack != null) {
				onItemChangedCallBack.Invoke ();
			}
			Debug.Log ("Added " + item.name);
		}
		return true;
	}

	//removes item from list
	public void Remove (Item item){

		items.Remove (item);

		if (onItemChangedCallBack != null) {
			onItemChangedCallBack.Invoke ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour {

	public bool open = false;

	public Transform openPosition;

	public void Clicked(){

		if (open == false) {
			transform.Translate (0, 235, 0);
			open = true;
		} else {
			transform.Translate (0, -235, 0);
			open = false;
		}
	}
}

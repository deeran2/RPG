using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour {

	public bool open = false;

	public void Clicked(){

		if (open == false) {
			transform.Translate (0, 190, 0);
			open = true;
		} else {
			transform.Translate (0, -190, 0);
			open = false;
		}
	}
}

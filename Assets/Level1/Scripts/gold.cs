using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour {

	public int goldAmount;

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Player") {
			other.GetComponentInChildren<PlayerHealthandExp> ().gold += goldAmount;
			Destroy (gameObject);
		}
	}
}

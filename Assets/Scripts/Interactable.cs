using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//being in box colider makes object interactable

	void OnTriggerStay(Collider other){
		if (other.transform.tag == "Player") {
			Interact ();
		}
	}
	//call to interact that will be overWritten
	public virtual void Interact(){
		
			Debug.Log("Interact method in Interactable");
		
	}
}

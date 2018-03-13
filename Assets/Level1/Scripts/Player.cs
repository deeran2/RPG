using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float moveSpeed;
	public float sideSpeed;
	public float rotSpeed;
	private Animator anim;




	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	void Update () {
		//Movement and Animation
		var v = Input.GetAxis ("Vertical");
		var h = Input.GetAxis ("Horizontal");
		transform.Translate (0, 0, v *Time.deltaTime * moveSpeed);
		transform.Rotate (0, h * Time.deltaTime * rotSpeed, 0);
		anim.SetFloat ("speed", v);

		if (Input.GetButtonDown ("Fire1")) {
			anim.SetTrigger ("attack");
		}
	}

}

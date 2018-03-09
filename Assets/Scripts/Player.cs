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
		var r = Input.GetAxis ("Camera");
		transform.Translate (0, 0, v *Time.deltaTime * moveSpeed);
		transform.Translate (h * Time.deltaTime * sideSpeed, 0, 0);
		transform.Rotate (0, -(r * CameraController.instance.yawSpeed * Time.deltaTime), 0);
		anim.SetFloat ("speed", v);



	}
}

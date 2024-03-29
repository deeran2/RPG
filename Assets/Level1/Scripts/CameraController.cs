﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public static CameraController instance;

	void Awake(){
		instance = this;
	}

	public Transform target;

	public Vector3 offset;
	public float zoomSpeed = 4f;
	public float minZoom = 1f;
	public float maxZoom =  3f;

	public float pitch = 1.5f; 

	public float yawSpeed = 100f;

	private float currentZoom = 10f;
	public float yawInput = 0f;

	void Update(){

		currentZoom -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
		currentZoom = Mathf.Clamp (currentZoom, minZoom, maxZoom);

		yawInput -= Input.GetAxis ("Camera") * yawSpeed * Time.deltaTime;
	}

	void LateUpdate(){

		transform.position = target.position - offset * currentZoom;
		transform.LookAt (target.position + Vector3.up * pitch);

		transform.RotateAround (target.position, Vector3.up, yawInput);
	}
}

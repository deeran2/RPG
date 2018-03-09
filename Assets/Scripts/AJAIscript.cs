using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AJAIscript : MonoBehaviour {

	public Transform player;
	public bool waiting = false;
	Animator anim;
	NavMeshAgent agent;
	public Transform[] waypoints;

	float alertDistance = 10f;
	float attackDistance = 1.4f;
	float pursueDistance = 7f;
	float remainingDistance = 1f;
	int selectedDestination;

	string state;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		agent.enabled = false;


	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = player.position - transform.position;
		direction.y = 0;
		float angle = Vector3.Angle (direction, transform.forward);
		//IDLE
		if (direction.magnitude > alertDistance & state !="Walking") {
			state = "Idle";


		}//ALERT
		else if (direction.magnitude < alertDistance && direction.magnitude > pursueDistance) {
			state = "Alert";

		}//PURSUE 
		else if (direction.magnitude < pursueDistance && direction.magnitude > attackDistance && angle < 60) {
			state = "Pursue";	

		}//ATTACKING
		else if (direction.magnitude < attackDistance) {
			state = "Attack";

		}
	

		switch (state) {
		case "Alert":
			agent.enabled = false;
			anim.SetBool ("isAlert", true);
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isWalking", false);
			break;
		case "Attack":
			anim.SetBool ("isAttacking", true);
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isAlert", false);
			anim.SetBool ("isWalking", false);

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 1f * Time.deltaTime);
			agent.enabled = false;
			break;
		case "Idle":
			agent.enabled = false;
			anim.SetBool ("isAlert", false);
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isWalking", false);
			if (waiting == false) {
				StartCoroutine (RandomMovement ());
			}
			break;
		case "Walking":
			anim.SetBool ("isAlert", false);
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isWalking", true);

			agent.enabled = true; 
			agent.SetDestination (waypoints [selectedDestination].position);
			if (Vector3.Distance (waypoints [selectedDestination].position, transform.position)
				< remainingDistance) {
				state = "Idle";
			}
			break;
		case "Pursue":
			agent.enabled = true;
			anim.SetBool ("isAlert", false);
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isWalking", true);

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), 1f * Time.deltaTime);
			agent.SetDestination (player.position);
			break;
		default:
			Debug.Log ("Default State");
			break;
		}
	}
	public IEnumerator RandomMovement(){
		waiting = true;
		int index = Random.Range (1, 6);

		yield return new WaitForSeconds (index);
		int index2 = Random.Range (1, 3);
		switch (index2) {
		case 1:
			break;
		case 2:
			selectedDestination = Random.Range (0, waypoints.Length);
			state = "Walking";
			break;

		}
		waiting = false;
	}
}

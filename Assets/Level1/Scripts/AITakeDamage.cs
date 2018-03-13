using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AITakeDamage : MonoBehaviour {

	int currentHealth;
	public int maxHealth;
	public int armor;
	int damage;
	public int expGiven;
	public Slider Exp;

	public Transform lootSpawn;
	public GameObject[] loot;


	bool preformed= false;
	 
	void Start(){
		currentHealth = maxHealth;


	}
	void Update(){
		damage = EquipmentManager.instance.damage;

		if (currentHealth <= 0) {
			Die ();
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Weapon") {
			TakeDamage ();
		}
	}
	void TakeDamage (){
		int damageTaken = (damage - armor);
		damageTaken = Mathf.Clamp (damageTaken, 0, damage);
		currentHealth -= damageTaken;
	}
	void Die(){
		if (preformed == false) {
			currentHealth = 0;
			GetComponent<AJAIscript> ().enabled = false;
			GetComponent<Animator> ().SetBool ("isDead", true);
			StartCoroutine (Wait ());
			Exp.value += expGiven;

			preformed = true;

		}
	}
	void SpawnLoot(){

	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (2f);
		for (int i = 0; i < loot.Length; i++) {
			Vector3 temp = new Vector3 (Random.Range (-1.0f, 1.0f), 0, Random.Range (-1.0f, 1.0f));
			Instantiate (loot [i], lootSpawn.position + temp, lootSpawn.rotation);
		}
		Destroy (gameObject);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthandExp : MonoBehaviour {

	public Slider healthSlider;
	int currentHealth;
	int maxHealth = 10;
	int armor;
	bool gameover = false;
	public GUIStyle style;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		armor = EquipmentManager.instance.armor;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = currentHealth;
	}
	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Enemy") {
			TakeDamage (other);
		}
		if (currentHealth <= 0) {
			Death ();


		}
	}
	void TakeDamage(Collider other){
		int damage = other.GetComponent<AIDoDamage>().damage;
		int damageTaken = (damage - armor);
		damageTaken = Mathf.Clamp (damageTaken, 0, damage);
		Debug.Log (damageTaken);
		currentHealth -= damageTaken;
	}
	void Death(){
		currentHealth = 0;
		gameover = true;
		GetComponentInParent<Player> ().enabled = false;
		//Play death animation
	}
	void OnGUI(){
		if (gameover == true) {
			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 100, 50), "GAME OVER", style);
		}
	}
}

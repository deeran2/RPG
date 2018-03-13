using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

	#region Singleton
	public Sprite icon;
	public Image[] image;
	public static EquipmentManager instance;

	void Awake(){
		if (instance != null) {

			Destroy (gameObject);
			return;
		}
		instance = this;
	}
	#endregion

	public Equipment[] defaultItems;

	public SkinnedMeshRenderer targetMesh;
	public Equipment[] currentEquipment;
	SkinnedMeshRenderer [] currentMeshes;
	public GameObject[] weapons;
	public GameObject[] shields;


	public delegate void OnEquipmentChanged (Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;

	Inventory inventory;
	GameObject player;

	public int armor = 1;
	public int damage = 1;

	Animator anim;

	void Start(){
		inventory = Inventory.instance;
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = player.GetComponent<Animator> ();

		int numSlots = System.Enum.GetNames (typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numSlots];
		currentMeshes = new SkinnedMeshRenderer[numSlots];

		EquipDefaultItems ();
	}

	//When icon is clicked in inventory, set new equipment to slot index
	//set blendshapes of new equip, instantiate new mesh, and set transform and bones to target's
	public void Equip(Equipment newItem){

		int slotIndex = (int)newItem.equipSlot;
		Equipment oldItem = Unequip (slotIndex);

		if (onEquipmentChanged != null) {

			onEquipmentChanged.Invoke (newItem, oldItem);
		}
		if ((int)newItem.equipSlot == 4) {

			weapons [newItem.weaponType].SetActive (true);
			anim.SetInteger ("weaponType", newItem.weaponType);
		
		} else if ((int)newItem.equipSlot == 5) {

			shields [newItem.weaponType].SetActive (true);
			anim.SetInteger ("shieldType", newItem.weaponType);


		}
		currentEquipment [slotIndex] = newItem;
		image[slotIndex].sprite = currentEquipment[slotIndex].icon;

		armor += newItem.armorModifier;
		damage += newItem.damageModifier;

		SetEquipmentBlendShapes (newItem, 100);
		if (newItem.mesh != null) {
			SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer> (newItem.mesh);
			newMesh.transform.parent = targetMesh.transform;
			newMesh.bones = targetMesh.bones;
			newMesh.rootBone = targetMesh.rootBone;
			currentMeshes [slotIndex] = newMesh;
		}

	}


	public Equipment Unequip (int slotIndex){

		if (currentEquipment [slotIndex] != null) {

			if(currentMeshes [slotIndex] != null){
			Destroy (currentMeshes [slotIndex].gameObject);
		}

			Equipment oldItem = currentEquipment [slotIndex];
			inventory.Add (oldItem);
			currentEquipment [slotIndex] = null;

			if (slotIndex == 4) {

				weapons [oldItem.weaponType].SetActive (false);
				anim.SetInteger ("weaponType", 0);
				image [slotIndex].sprite = icon;



			} else if (slotIndex == 5) {
				
				shields [oldItem.weaponType].SetActive (false);
				anim.SetInteger ("shieldType", 0);
				image [slotIndex].sprite = icon;
			
			}

			armor -= oldItem.armorModifier;
			damage -= oldItem.damageModifier;

		SetEquipmentBlendShapes (oldItem, 0);
		if (onEquipmentChanged != null) {

			onEquipmentChanged.Invoke (null, oldItem);
		}
		return oldItem;
	}
		return null;
	}

	public void UnequipAll(){

		for (int i = 0; i < currentEquipment.Length; i++) {

			Unequip (i);
		}
		EquipDefaultItems ();
	}

	void SetEquipmentBlendShapes (Equipment item, int weight){

		foreach (EquipmentMeshRegion blendshape in item.coveredMeshRegions) {
			targetMesh.SetBlendShapeWeight ((int)blendshape, weight);
		}
	}

	void EquipDefaultItems(){

		foreach(Equipment item in defaultItems){
			Equip (item);
		}
	}
	void Update(){

		if (Input.GetKeyDown (KeyCode.U)) {
			UnequipAll ();
		}
		if (currentEquipment [4] == null) {
			weapons [0].SetActive (true);
		} else {
			weapons [0].SetActive (false);
		}
	}
	public void EquipmentButton(int slot){
		Unequip (slot);
		if (slot > 3) {
			image [slot].sprite = icon;
		} else {
			Equip (defaultItems [slot]);
		}
	}
}

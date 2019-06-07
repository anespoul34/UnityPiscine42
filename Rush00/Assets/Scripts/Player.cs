using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Weapon weapon;

	public Text WeaponName;
	public Text Ammo;
	public Text Auto;
	public SoundManager soundManager;

	void Start () {
		WeaponName.text = "No Weapon";
		Ammo.text = "-";
		Auto.text = "";
	}

	public void death(){
		soundManager.PlayDeath(transform.position);		
		Destroy (gameObject);
	}

	void FixedUpdate () {
		if (weapon) {
			WeaponName.text = weapon.name;
			Ammo.text = weapon._Ammo.ToString();
			if (weapon._NbProj > 1)
				Auto.text = "Auto";
			else 
				Auto.text = "Single";
		} else {
			WeaponName.text = "No Weapon";
			Ammo.text = "-";
			Auto.text = "";
		}
		if (weapon && Input.GetMouseButton(0)) {
			weapon.Shoot ();
		} else if (weapon && Input.GetMouseButton(1)) {
			soundManager.EjectSound(transform.position);
			weapon.Lacher ();
			weapon.GetComponent<SpriteRenderer>().sprite = weapon.noHand;
			weapon = null;
		}
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (Input.GetKeyDown(KeyCode.E) && collider.gameObject.layer == 11 && !weapon) {
			soundManager.ReloadSound(transform.position);
			weapon = collider.gameObject.GetComponent<Weapon>();
			weapon.GetComponent<SpriteRenderer>().sprite = weapon.hand;
			weapon.transform.parent = transform;
			weapon.GetComponent<SpriteRenderer>().sortingOrder = 4;
			weapon.GetComponent<SpriteRenderer>().flipY = true;
			weapon.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			weapon.transform.rotation = transform.rotation;
			weapon.GetComponent<BoxCollider2D> ().enabled = false;
		}

	}
}
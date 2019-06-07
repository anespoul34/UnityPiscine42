using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersManager : MonoBehaviour {

	public List<Soldier> soldiers = new List<Soldier>();
	public List<AudioClip> sounds;
	public List<AudioClip> service;

	private Collider2D hitCollider;
	private Vector2 ray;
	private AudioSource source;

	void Start () {
		ray = new Vector3(0, 0);
		source = GetComponent<AudioSource>();
	}
	
	void Update () {
		
		if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl) == true)
			addSoldier ();
		else if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);			
			hitCollider = Physics2D.OverlapPoint(ray);
			if (hitCollider && hitCollider.gameObject.layer == 8)
			{
				resetSoldiersSelection();
				soldiers.Add(hitCollider.transform.GetComponent<Soldier>());
				hitCollider.transform.GetComponent<Soldier>().ChangeMovement(Soldier.UnitMovement.STOP);
				hitCollider.transform.GetComponent<Soldier>().selected = true;
				if (!source.isPlaying)
					source.PlayOneShot(service[Random.Range(0, 5)], 1);
			} else if (hitCollider && hitCollider.gameObject.layer == 9) {
				foreach (Soldier soldier in soldiers)
				{
					if (soldier.selected)
						soldier.orc = hitCollider.transform.GetComponent<Orc>();
				}
				Attack ();
			} else {
				if (checkSoldiersList ()) {
					if (!source.isPlaying)
						source.PlayOneShot(sounds[Random.Range(0, 3)], 1);
					moveSoldiers();	
				}
			}
		}
		else if (Input.GetMouseButtonDown(1)) 
			resetSoldiersSelection ();
	}

	private void moveSoldiers () {
		foreach (Soldier soldier in soldiers)
		{
			if (soldier.selected) {
				soldier.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				soldier.ChangeMovement(Soldier.UnitMovement.MOVE);
			}
		}
	}

	private void Attack () {
		foreach (Soldier soldier in soldiers)
		{
			if (soldier.selected) {
				soldier.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				soldier.ChangeMovement(Soldier.UnitMovement.CHASE);
			}
		}
	}

	private void addSoldier () {
			ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);			
			hitCollider = Physics2D.OverlapPoint(ray);
			if (hitCollider && hitCollider.gameObject.layer == 8)
			{
				soldiers.Add(hitCollider.transform.GetComponent<Soldier>());
				hitCollider.transform.GetComponent<Soldier>().ChangeMovement(Soldier.UnitMovement.STOP);
				hitCollider.transform.GetComponent<Soldier>().selected = true;
				if (!source.isPlaying)
					source.PlayOneShot(service[Random.Range(0, 5)], 1);
			}
	}

	private void resetSoldiersSelection () {
		foreach (Soldier soldier in soldiers) {
			soldier.selected = false;
			soldier.ChangeMovement(Soldier.UnitMovement.STOP);
		}
	}

	bool checkSoldiersList () {
		foreach (Soldier soldier in soldiers) {
			if (soldier.selected)
				return true;
		}
		return false;
	}
}
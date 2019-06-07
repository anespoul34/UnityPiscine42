using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBuilding : MonoBehaviour {

	public GameObject unit;
	public float spawnWait;
	public int startWait;

	private float time;
	private int Hp = 200;

	void Start () 
	{
		StartCoroutine(Spawner());
	}
	
	void Update () 
	{
		spawnWait = 10;	
	}

	IEnumerator Spawner () 
	{
		yield return new WaitForSeconds (startWait);

		while (Hp > 0)
		{
			Vector3 spawnPosition = new Vector3 (transform.position.x - 1.5f, transform.position.y - 1f, transform.position.z);
			Instantiate (unit, spawnPosition, gameObject.transform.rotation);
		
			yield return new WaitForSeconds (spawnWait);
		}
	}
}

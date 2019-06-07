using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour {

	public List<Mob> unit;
	public Transform player;
	public GameObject healthBar;
	public Slider slider;
	public Text nameText;
	public Text lvlText;

	private Mob enemy;


	void Start ()
	{
		enemy = Instantiate (unit[Random.Range(0, 2)], transform.position, transform.rotation);
		enemy.player = player;
		enemy.healthBar = healthBar;
		enemy.sliderHp = slider;
		enemy.nameText = nameText;
		enemy.lvlText = lvlText;
		StartCoroutine(Spawner());
	}

	void Update (){	
	}

	IEnumerator Spawner ()
	{
		while (true)
		{
			if (enemy == null)
			{
				enemy = Instantiate (unit[Random.Range(0, 1)], transform.position, gameObject.transform.rotation);			
				enemy.player = player;
				enemy.healthBar = healthBar;
				enemy.sliderHp = slider;	
				enemy.nameText = nameText;
				enemy.lvlText = lvlText;		
			}
			yield return new WaitForSeconds (Random.Range(5, 10));					
		}
	}
}
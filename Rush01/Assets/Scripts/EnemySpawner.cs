﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject player;
	public GameObject loot;

	private GameObject spawned;
	private float time;
	private float timer;

	void Start () {
		SpawnEnemy();
	}
	
	void Update () {
		if (spawned == null)
			time += Time.deltaTime;
		if (time >= timer)
			SpawnEnemy();
	}

	void SpawnEnemy () {
		spawned = GameObject.Instantiate(enemies[Random.Range(0, enemies.Length)], transform);
 		spawned.name = spawned.name.Replace("(Clone)","").Trim();
		Enemy enemy = spawned.GetComponent<Enemy>();
		enemy.level = player.GetComponent<Maya>().level;
		enemy.strength = Random.Range(8, 13);
		enemy.agility = Random.Range(8, 13);
		enemy.constitution = Random.Range(8, 13);
		enemy.armor = Random.Range(1, 5);
		enemy.money = Random.Range(0, 50);
		timer = Random.Range(3.5f, 7.5f);
		enemy.loot = loot;

		if (enemy.level > 1) {
			float factor = 0.15f * (enemy.level - 1);
			enemy.strength = Mathf.RoundToInt((enemy.strength + (enemy.strength * factor)));
			enemy.agility = Mathf.RoundToInt((enemy.agility + (enemy.agility * factor)));
			enemy.constitution = Mathf.RoundToInt((enemy.constitution + (enemy.constitution * factor)));
			//enemy.armor = Mathf.RoundToInt((enemy.armor + (enemy.armor * factor)));
			enemy.money = Mathf.RoundToInt((enemy.money + (enemy.money * factor)));
			enemy.exp = (enemy.exp + (enemy.exp * factor));
		}
		
		enemy.maxHealthPoints = enemy.constitution * 5;
		enemy.healthPoints = enemy.maxHealthPoints;
		enemy.minDamage = enemy.strength / 2;
		enemy.maxDamage = enemy.minDamage + 4;

		time = 0;
	}
}

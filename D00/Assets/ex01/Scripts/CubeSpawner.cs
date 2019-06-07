using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public GameObject cubes;
	public float spawnTime;

	private GameObject cube;
	private float timer;

	// Use this for initialization
	void Start () {
		spawnTime += Random.Range(1.0f, 3.0f);		
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= spawnTime) {
			if (!cube) {
				timer = 0;
				spawnTime = Random.Range(1.0f, 5.0f);			
				cube = (GameObject)GameObject.Instantiate(cubes, cubes.transform.position, Quaternion.identity);
			}
		}
		if (cube && Input.GetKeyDown(KeyCode.A) && cubes.name == "A") {
			Debug.Log("Precision: " + cube.transform.position.y);
			Destroy(cube);
		}
		if (cube && Input.GetKeyDown(KeyCode.S) && cubes.name == "S") {
			Debug.Log("Precision: " + cube.transform.position.y);
			GameObject.Destroy(cube);
		}
		if (cube && Input.GetKeyDown(KeyCode.D) && cubes.name == "D") {
			Debug.Log("Precision: " + cube.transform.position.y);
			GameObject.Destroy(cube);
		}
		if (cube && cube.transform.position.y < -1) {
			Debug.Log("Bad !");
			GameObject.Destroy(cube);
		}
		timer += Time.deltaTime;
	}
}

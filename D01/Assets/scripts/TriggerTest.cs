using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

	public GameObject wall;

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "blue" || collider.name == "red")
			wall.transform.position = new Vector3(wall.transform.position.x, -4f, 0f);
		if (collider.name == "yellow")
			wall.transform.position = new Vector3(wall.transform.position.x, -4.6f, 0f);
	}
}

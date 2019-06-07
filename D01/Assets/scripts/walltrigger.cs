using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walltrigger : MonoBehaviour {

	public GameObject wall;
	public string player;

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == player)
			wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y - 4f, wall.transform.position.z);
		transform.position = new Vector3(transform.position.x, 0.03f, transform.position.z);
	}
	void OnTriggerExit2D(Collider2D collider) {
		if (collider.name == player)
			wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + 4f, wall.transform.position.z);
		transform.position = new Vector3(transform.position.x, 0.08f, transform.position.z);		
	}
}
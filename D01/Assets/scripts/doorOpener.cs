using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour {

	public GameObject wall;
	public Vector3 size;

	private Vector3 startSize;
	private Vector3 buttonPos;

	void Start () {
		startSize = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, wall.transform.localScale.z);
		buttonPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		wall.transform.localScale = size;
		transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
	}
	void OnTriggerExit2D(Collider2D collider) {
		wall.transform.localScale = startSize;
		transform.position = buttonPos;		
	}
}
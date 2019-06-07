using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorOpener : MonoBehaviour {

	public GameObject floor1;
	public GameObject floor2;

	private Vector3 floor1Pos;
	private Vector3 floor2Pos;
	private Vector3 buttonPos;

	void Start () {
		floor1Pos = new Vector3(floor1.transform.position.x, floor1.transform.position.y, floor1.transform.position.z);
		floor2Pos = new Vector3(floor2.transform.position.x, floor2.transform.position.y, floor2.transform.position.z);
		buttonPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		floor1.transform.position = new Vector3(floor1.transform.position.x - 2f, floor1.transform.position.y, floor1.transform.position.z);
		floor2.transform.position = new Vector3(floor2.transform.position.x + 2f, floor2.transform.position.y, floor2.transform.position.z);
		transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, transform.position.z);
	}
	void OnTriggerExit2D(Collider2D collider) {
		floor1.transform.position = floor1Pos;
		floor2.transform.position = floor2Pos;
		transform.position = buttonPos;		
	}
}

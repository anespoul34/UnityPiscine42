using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public Vector3 pos;

	void OnTriggerEnter2D(Collider2D collider) {
		collider.transform.position = pos;
	}
}
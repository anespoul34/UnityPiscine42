using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	private float moveSpeed;

	void Start () {
		moveSpeed = Random.Range(2.0f, 8.0f);
	}
	
	void Update () {
		transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * moveSpeed);	
	}
}

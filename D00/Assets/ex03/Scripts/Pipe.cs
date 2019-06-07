using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	public bool play = true;
	public float score = 0.0f;

	private float speed = 3.0f;
	private bool check = true;

	void Start () {
	}
	
	void Update () {
		if (play) {
			transform.Translate((-speed * Time.deltaTime), 0f, 0f);
			if (transform.position.x < -7.9f && check == true) {
				score += 5f;
				check = false;
			}
			if (transform.position.x < -14f) {
				transform.position = new Vector3(14f, 8f, -1f);
				speed += 1.0f;
				check = true;
			}
		}
	}
}

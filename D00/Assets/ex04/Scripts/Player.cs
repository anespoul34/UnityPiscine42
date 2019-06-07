using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject player;

	private float moveSpeed = 20f;

	void Start () {
		
	}
	
	void Update () {

		if (player.name == "leftPlayer" && Input.GetKey(KeyCode.S) && transform.position.y >= 2.35f)
			transform.Translate(0f, (-moveSpeed * Time.deltaTime), 0f);
		if (player.name == "leftPlayer" && Input.GetKey(KeyCode.W) && transform.position.y <= 11.62f)
			transform.Translate(0f, (moveSpeed * Time.deltaTime), 0f);

		if (player.name == "rightPlayer" && Input.GetKey(KeyCode.DownArrow) && transform.position.y >= 2.35f)
			transform.Translate(0f, (-moveSpeed * Time.deltaTime), 0f);
		if (player.name == "rightPlayer" && Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 11.62f)
			transform.Translate(0f, (moveSpeed * Time.deltaTime), 0f);
	}
}

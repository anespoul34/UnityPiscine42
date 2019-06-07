using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

	public GameObject leftPlayer;
	public GameObject rightPlayer;

	private float moveSpeed = 7.5f;
	private float vDir = 1.5f;
	private float hDir = 1.5f;
	private float leftScore = 0.0f;
	private float rightScore = 0.0f;

	void Start () {
		
	}
	
	void Update () {

		if (transform.position.y >= 12.7132f)
		{
			vDir *= -1;
			transform.position = new Vector3(transform.position.x, 12.7f, 0f);
		}
		if (transform.position.y <= 1.3312f)
		{
			vDir *= -1;
			transform.position = new Vector3(transform.position.x, 1.34f, 0f);
		}

		transform.Translate(moveSpeed * hDir * Time.deltaTime, moveSpeed * vDir * Time.deltaTime, 0f);

		if (transform.position.x >= 15f || transform.position.x <= -15f)
		{
			if (transform.position.x >= 15f)
				leftScore += 1;
			if (transform.position.x <= -15f)
				rightScore += 1;
			transform.position = new Vector3(0f, 7f, 0f);
			moveSpeed = 7.5f;
			Debug.Log("Player 1: " + leftScore + " | Player 2: " + rightScore);
		}

		if (transform.position.x <= -9.9f && transform.position.x >= -11f &&  ((leftPlayer.transform.position.y + 1.5f) >= transform.position.y && (leftPlayer.transform.position.y - 1.5f) <= transform.position.y))
		{
			hDir *= -1;
			moveSpeed += 0.5f;
			transform.position = new Vector3(-10, transform.position.y, 0f);
		}
		if (transform.position.x >= 9.9f && transform.position.x <= 11f &&  ((rightPlayer.transform.position.y + 1.5f) >= transform.position.y && (rightPlayer.transform.position.y - 1.5f) <= transform.position.y))
		{
			hDir *= -1;
			moveSpeed += 0.5f;
			transform.position = new Vector3(10, transform.position.y, 0f);
		}	
	}
}

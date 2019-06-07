using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public bool move;
	public float speed;
	public GameObject Club_Object;

	private Club club;
	private float deceleration = 0.1f;

	void Start () {
		move = false;
		club = Club_Object.GetComponent<Club>();		
	}
	
	void Update () {
		if (move)
		{	
			transform.Translate(new Vector3(0f, (Time.deltaTime * speed), 0f));
			if (deceleration < 1.0f)
				deceleration *= 1.06f;
			
			if (speed > 0.0f)
				speed -= deceleration;
			else
				speed += deceleration;

			if (transform.position.y <= 17f && transform.position.y >= 16f && speed <= 5f && speed >= -5f)
			{
				Debug.Log("You did it ! Score: " + club.score);
				transform.position = new Vector3(0f, 16.5f, 10f);
				club.play = false;
				move = false;
			}

			if (transform.position.y > 19f || transform.position.y < 1f)
				speed = -speed;

			if (speed <= 0.7f && speed >= -0.7f)
			{
				if (transform.position.y < 16.5f)
					club.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f, transform.position.z);
				else 
					club.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 1.9f, transform.position.z);
				deceleration = 0.1f;
				move = false;
				club.score += 5;
				Debug.Log("Score: " + club.score);
			}
		}
	}
}
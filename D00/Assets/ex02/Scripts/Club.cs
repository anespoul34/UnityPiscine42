using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {

	public GameObject Ball_Object;
	public bool play = true;
	public float score = -15;

	private Ball ball;
	private float power = 0;
	private bool loose = false;

	void Start () {
		ball = Ball_Object.GetComponent<Ball>();
	}
	
	void Update () {
		if (play) {
			bool held = Input.GetKey(KeyCode.Space);
			if (held)
			{
				power = Mathf.Clamp(power+2.0f, 0.1f, 50.0f);
			
				if (ball.transform.position.y < 16.5f)
					transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - 0.03f, ball.transform.position.y - 1.4f, transform.position.y), transform.position.z);
				else 
					transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + 0.03f, ball.transform.position.y + 1.9f, ball.transform.position.y + 3.3f), transform.position.z);
			
			}
			if (power > 0 && !held)
			{
				if (ball.transform.position.y < 16.5f)
				{
					transform.position = new Vector3(ball.transform.position.x - 0.3f, ball.transform.position.y + 0.4f, ball.transform.position.z);
					ball.speed = power;
				}	
				else {
					transform.position = new Vector3(ball.transform.position.x - 0.3f, ball.transform.position.y + 1.9f, ball.transform.position.z);
					ball.speed = -power;
				}
				ball.move = true;
				power = 0;
			}
			if (score >= 0 && loose == false) {
				Debug.Log("Too many shots ! Score: 0");
				loose = true;
			}
		}
	}
}
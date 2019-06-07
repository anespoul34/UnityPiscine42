using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public GameObject Pipe_Object;

	private Pipe pipe;
	private bool play = true;

	void Start () {
		pipe = Pipe_Object.GetComponent<Pipe>();
	}
	
	void Update () {

		if (play) {
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (transform.position.y < 20f)
					transform.Translate(0f, 2f, 0f);
			} else {
				transform.Translate(0f, -0.08f, 0f);
			}
			if (transform.position.y <= 2f) {
				pipe.play = false;
				play = false;
				Debug.Log("Score: " + pipe.score);
				Debug.Log("Time: " + Mathf.RoundToInt(Time.time) + "s");				
			}
			if ((transform.position.y >= 9.66f || transform.position.y <= 6.1f) && (pipe.transform.position.x <= -5f && pipe.transform.position.x >= -8f ))
			{
				pipe.play = false;
				play = false;
				Debug.Log("Score: " + pipe.score);
				Debug.Log("Time: " + Mathf.RoundToInt(Time.time) + "s");				
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBar : MonoBehaviour {


	public Vector3 velocity;
	private Vector3 start;

	void Start () {
		start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	void FixedUpdate () {
		if ((start.x + 3) < transform.position.x || (start.x - 5) > transform.position.x)
			velocity.x *= -1;
		transform.position += (velocity * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.collider.name == "red")
			collision.collider.transform.SetParent(transform);
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.name == "red")
			collision.collider.transform.SetParent(null);
	}
}
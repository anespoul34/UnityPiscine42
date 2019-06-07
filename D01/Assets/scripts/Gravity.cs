using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public float gravity;

	private void OnCollisionEnter2D(Collision2D collision) 
	{
		collision.collider.GetComponent<Rigidbody2D>().gravityScale = gravity;
	}
}
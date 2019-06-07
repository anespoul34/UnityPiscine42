using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.tag == "player")
		{
			Destroy(door1);
			Destroy(door2);
		}
	}
}

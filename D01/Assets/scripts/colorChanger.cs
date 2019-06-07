using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour {

	public GameObject door1;
	public GameObject door2;
	public GameObject door3;

	void Start () {
	}
	
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.name == "red") {
			door1.layer = 11;
			door1.GetComponent<SpriteRenderer>().color = new Color(0.839f, 0.270f, 0.258f);
			door2.layer = 12;
			door2.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.661f, 0.219f);
			door3.layer = 11;
			door3.GetComponent<SpriteRenderer>().color = new Color(0.839f, 0.270f, 0.258f);
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0.839f, 0.270f, 0.258f);
		}
		if (collider.name == "blue") {
			door1.layer = 13;
			door1.GetComponent<SpriteRenderer>().color = new Color(0.145f, 0.239f, 0.372f);
			door2.layer = 11;
			door2.GetComponent<SpriteRenderer>().color = new Color(0.839f, 0.270f, 0.258f);
			door3.layer = 13;
			door3.GetComponent<SpriteRenderer>().color = new Color(0.145f, 0.239f, 0.372f);
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0.145f, 0.239f, 0.372f);
		}
		if (collider.name == "yellow") {
			door1.layer = 12;
			door1.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.661f, 0.219f);
			door2.layer = 13;			
			door2.GetComponent<SpriteRenderer>().color = new Color(0.145f, 0.239f, 0.372f);			
			door3.layer = 12;			
			door3.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.661f, 0.219f);
			gameObject.GetComponent<SpriteRenderer>().color = new Color(0.705f, 0.661f, 0.219f);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public int speed = 10;
	string console;
	public Rigidbody2D _rb;
	public float angle;
    [SerializeField]
    bool enemy = false;
	
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
	}
	void Update () {
	}
	void FixedUpdate ()
	{
			// var pos = Camera.main.WorldToScreenPoint (transform.position);
			// var dir = Input.mousePosition - pos;
			// angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			// transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward); 

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        if (enemy)
            return;
		if (Input.GetKey(KeyCode.A))
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		if (Input.GetKey(KeyCode.D))
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		if (Input.GetKey(KeyCode.W))
			transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
		if (Input.GetKey(KeyCode.S))
			transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "arme")
			print ("Arme");
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "arme"){
			print("Plus sur arme");
		}
	}
}

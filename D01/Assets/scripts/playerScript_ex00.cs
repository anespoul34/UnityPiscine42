using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {

	public float playerSpeed;
	public Vector2 jumpHeight;
	public bool is_actif;

	private bool jumping;
	private Rigidbody2D rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
			if (gameObject.name == "red")
				is_actif = true;
			else 
				is_actif = false;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
			if (gameObject.name == "yellow")
				is_actif = true;
			else 
				is_actif = false;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
			if (gameObject.name == "blue")
				is_actif = true;
			else 
				is_actif = false;
        }

		if (is_actif) {
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			float horizontal = Input.GetAxis("Horizontal");
			handleMovement(horizontal);
			if (Input.GetKeyDown(KeyCode.Space) && !jumping && (rb.velocity.y <= 0.4f && rb.velocity.y >= -0.4f) ) {
				rb.AddForce(jumpHeight, ForceMode2D.Impulse);
				jumping = true;
			}
		} else {
			if (!jumping)
				rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		}
	}

	void handleMovement(float horizontal) {
		rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y);
	}

	void OnCollisionEnter2D (Collision2D collision) {
		jumping = false;
	}
}
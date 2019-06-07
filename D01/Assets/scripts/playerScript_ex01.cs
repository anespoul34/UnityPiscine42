using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex01 : MonoBehaviour {

	public float playerSpeed;
	public Vector2 jumpHeight;
	public bool is_actif;

	private bool jumping;
	private Rigidbody2D rb;
	private static bool blue = false;
	private static bool red = false;
	private static bool yellow = false;

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

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "yellow_exit" && gameObject.name == "yellow")
			yellow = true;
		if (collider.name == "red_exit" && gameObject.name == "red")
			red = true;
		if (collider.name == "blue_exit" && gameObject.name == "blue")
			blue = true;
		if (blue && red && yellow)
		{
			int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
			
			blue = false;
			red = false;
			yellow = false;
			Debug.Log("<== VICTORY ==>");
			if (nextSceneIndex <= 4)
				SceneManager.LoadScene(nextSceneIndex);
		}			
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.name == "yellow_exit" && gameObject.name == "yellow")
			yellow = false;
		if (collider.name == "red_exit" && gameObject.name == "red")
			red = false;
		if (collider.name == "blue_exit" && gameObject.name == "blue")
			blue = false;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "PlayerProjectile" || collision.gameObject.tag == "projectile") {
				Destroy(collision.gameObject);
		}
	}
}

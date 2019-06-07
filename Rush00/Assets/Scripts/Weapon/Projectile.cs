using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int _Velocity = 1;
    public bool _PlayerProj = true;

	private void Start()
	{
        if (_PlayerProj)
            tag = "PlayerProjectile";
        Destroy(gameObject, 5);
	}

	void FixedUpdate(){
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "player" && !_PlayerProj) {
			collision.gameObject.GetComponent<Player> ().death ();
			Destroy (this.gameObject);
		}
		else if (collision.gameObject.tag == "enemy" && _PlayerProj){
			collision.gameObject.GetComponent<Enemy>().Death();
			Destroy(this.gameObject);
		}
	}
}
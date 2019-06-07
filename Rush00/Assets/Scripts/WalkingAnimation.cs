using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour {

	private Animator animator;
	private bool is_moving;

	void Awake () {
		animator = GetComponent<Animator>();
	}

	void Start () {
		is_moving = false;
	}
	
	void Update () {

		is_moving = false;
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
			is_moving = true;		
		if (is_moving)
			animator.SetTrigger("walk");
		else
			animator.SetTrigger("stop");
	}
}

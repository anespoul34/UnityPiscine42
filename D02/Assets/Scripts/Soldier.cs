using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

	public float speed;
	public Vector3 target;
	public bool selected = false;
	public int Hp;
	public int Dmg;
	
	private Animator animator;
	private string direction;
	private bool is_moving = false;
	private bool attacking = false;
	[HideInInspector]
	public Orc orc;

	public enum UnitMovement {
		MOVE,
		STOP,
		CHASE,
		ATTACK,
		STAY
	};

	public UnitMovement movement;

	void Awake () {
		animator = GetComponent<Animator>();
	}
	void Start () {
		target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void Update () 
	{
		if (movement == UnitMovement.MOVE && selected)
		{
			// transform.rotation = Quaternion.identity;
			GetComponent<SpriteRenderer>().flipX = false;
			Move ();
			if (is_moving) {
				animator.SetTrigger (direction);
			} else {
				direction = "Stop";
				animator.SetTrigger (direction);			
			}
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);		
			if (transform.position == target)
			{
				is_moving = false;
				ChangeMovement(UnitMovement.STOP);
			}
		}
		else if (movement == UnitMovement.STOP)
		{
			if (is_moving)
			{
				if (transform.position == target)
				{
					is_moving = false;
					direction = "Stop";
				} else {
					transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);				
				}
			} else {
				direction = "Stop";			
			} 
			animator.SetTrigger (direction);
			if (attacking)
				movement = UnitMovement.ATTACK;
		}
		else if (movement == UnitMovement.CHASE && orc)
		{
			target = orc.transform.position;
			// transform.rotation = Quaternion.identity;
			GetComponent<SpriteRenderer>().flipX = false;
			Move ();
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
			if (is_moving) {
				animator.SetTrigger (direction);
			} else {
				direction = "Stop";
				animator.SetTrigger (direction);			
			}
		}
		else if (movement == UnitMovement.ATTACK)
		{
			if (selected)
				Debug.Log("here");
			direction = "Attack";
			animator.SetTrigger (direction);
		}
	}

	void OnCollisionEnter2D (Collision2D collider)
	{
		Debug.Log("Enter");
		target = transform.position;
		attacking = true;
		movement = UnitMovement.STOP;
	}

	public void ChangeMovement (UnitMovement _movement)
	{
		movement = _movement;
	}

	public void Move () {
        target.z = transform.position.z;
		CheckDirection (target);		
		is_moving = true;
	}

	public void CheckDirection (Vector3 target) {

		float x = target.x - transform.position.x;
		float y = target.y - transform.position.y;
		float d = Vector2.Distance(target, transform.position);
		float angle = Mathf.Sin(y / d);

		// transform.Rotate(0f, 0f, (angle - 0.45f));

		if (y > 0 && x > 0)
		{
			if (angle > 0.7)
				direction = "WalkUp";
			else if (angle > 0.2 && angle <= 0.7)
				direction = "WalkTR";
			else
				direction = "WalkRight";
		}
		if (y > 0 && x < 0)
		{
			if (angle > 0.7)
				direction = "WalkUp";
			else if (angle > 0.2 && angle <= 0.7)
			{
				GetComponent<SpriteRenderer>().flipX = true;
				direction = "WalkTR";
			}
			else
			{
				GetComponent<SpriteRenderer>().flipX = true;
				direction = "WalkRight";
			}
		}
		if (y < 0 && x > 0)
		{
			if (angle < -0.7)
				direction = "WalkDown";
			else if (angle >= -0.7 && angle < -0.2)
				direction = "WalkDR";
			else
				direction = "WalkRight";
		}
		if (y < 0 && x < 0)
		{
			if (angle < -0.7)
				direction = "WalkDown";
			else if (angle < -0.2 && angle >= -0.7)
			{
				GetComponent<SpriteRenderer>().flipX = true;
				direction = "WalkDR";				
			}
			else
			{
				GetComponent<SpriteRenderer>().flipX = true;
				direction = "WalkRight";
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

	NavMeshAgent agent;

	private Animator animator;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}
	
	void Update () {

		if (Input.GetMouseButton(0) && GetComponent<FightPlayer>().Target == null) 
		{
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) 
			{
				animator.SetBool("Attack", false);
				animator.SetBool("Run", true);
				agent.destination = hit.point;
			}
		}

		if (Vector3.Distance(transform.position, agent.destination) <= 0.5f)
			animator.SetBool("Run", false);
	}

}
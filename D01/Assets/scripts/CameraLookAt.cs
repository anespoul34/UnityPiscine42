using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {
    
	public GameObject[] targets;
    
	private GameObject target;
	void Start () {
		target = targets[0];
	}

    void Update () {
		
		if (Input.GetKeyDown(KeyCode.Keypad1))
			target = targets[0];
		if (Input.GetKeyDown(KeyCode.Keypad2))
			target = targets[1];
		if (Input.GetKeyDown(KeyCode.Keypad3))
			target = targets[2];

		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
    }
}
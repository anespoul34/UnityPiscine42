using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {
	public GameObject target;
	void Start () {
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -10f);
	}
	
	void Update () {
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -10f);		
	}
}

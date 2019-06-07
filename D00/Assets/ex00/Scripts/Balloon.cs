using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	private float size = 0.1f;
	private float breath = 0.0f;
	private float sufocate = 0.0f;
	private float buttonTime = 0.0f;

	void Start () {
		breath = 0.0f;
		sufocate = 0.0f;
		size = 0.1f;
	}

	void Update () {
		if (breath >= 0.0f)
			breath += -0.25f * Time.deltaTime;
		if (sufocate >= 0.0f)
			sufocate += -1.0f * Time.deltaTime;
		if (size >= 0.1f)
			size += -0.2f * Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space) && sufocate <= 0.0f) {

			float tempTime = Time.time - buttonTime;
			buttonTime = Time.time;

			size += 0.15f;
			breath += 0.2f - tempTime * 0.1f;


			if (breath >= 1.5f) {
				breath = 0.0f;
				sufocate = 2.0f;
			}
		}
		transform.localScale = new Vector3(size, size, size);

		if (size >= 4.0f)
		{
			Destroy(gameObject);
			Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + 's');
		}
	}
}
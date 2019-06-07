using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour {

	public AudioClip test;

	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
			source.PlayOneShot(test, 1);		
	}
}

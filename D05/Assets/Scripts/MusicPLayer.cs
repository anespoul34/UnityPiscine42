using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPLayer : MonoBehaviour {

	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	void Start () {
		source.loop = true;
		source.Play();
	}
}

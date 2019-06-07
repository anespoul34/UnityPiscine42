using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip ironShot;
	public AudioClip woodShot;
	public AudioClip putterShot;
	public AudioClip wedgeShot;
	public AudioClip applause;
	public AudioClip waterSplash;
	public AudioClip ballInHole;
	public AudioClip victory;

	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	public void PlayIronShot(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(ironShot);
	}
	public void PlayWoodShot(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(woodShot);
	}
	public void PlayPutterShot(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(putterShot);
	}
	public void PlayWedgeShot(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(wedgeShot);
	}
	public void PlayApplause(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(applause);
	}
	public void PlayWaterSplash(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(waterSplash);
	}
	public void PlayBallInHole(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(ballInHole);
	}
	public void PlayVictory(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(victory);
	}
}

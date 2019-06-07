using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public List<AudioClip> deathSounds;
	public AudioClip shootSound;
	public AudioClip wooshSound;
	public AudioClip reloadSound;
	public AudioClip ejectSound;
	public AudioClip winSound;
	public AudioClip looseSound;

	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	public void PlayDeath(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(deathSounds[Random.Range(0, 3)], 1);
	}

	public void ShootSound(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(shootSound);
	}

	public void WooshSound(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(wooshSound);
	}

	public void ReloadSound(Vector3 pos) {
		transform.position = pos;
		source.PlayOneShot(reloadSound);
	}
	public void EjectSound(Vector3 pos) {
		transform.position = pos;		
		source.PlayOneShot(ejectSound);
	}
	public void WinSound(Vector3 pos) {
		transform.position = pos;		
		source.PlayOneShot(winSound);
	}
	public void LooseSound(Vector3 pos) {
		transform.position = pos;		
		source.PlayOneShot(looseSound);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandomizer : MonoBehaviour
{

    [SerializeField]
    List<AudioClip> AudioClips;
    AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.clip = AudioClips[Random.Range(0, AudioClips.Count)];
        source.Play();
	}




	private void Update()
	{
        float progress = Mathf.Clamp01(source.time / source.clip.length);
        if (progress == 1f)
        {
            source.clip = AudioClips[Random.Range(0, AudioClips.Count)];
            source.Play();

        }

	}

}

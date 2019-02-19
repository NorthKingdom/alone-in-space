using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip ambientSound;
    public AudioClip introSoundtrack;

    private AudioSource _audioSource;

	// Use this for initialization
	void Awake () {
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayIntroSounds() {
        _audioSource.PlayOneShot(introSoundtrack, 1.0f);
    }

    public void PlayGameSounds()
    {
        _audioSource.PlayOneShot(ambientSound, 0.5f);
    }
}

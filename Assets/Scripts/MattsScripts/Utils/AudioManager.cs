using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;

	void Awake ()
	{
	    audioSource = GetComponent<AudioSource>();
	}

    public void PlayOneShot(AudioClip clipToPlay)
    {
        audioSource.PlayOneShot(clipToPlay);
    }
}

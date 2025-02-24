using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource vfxAudioSource;

    public AudioClip musicClip;
    public AudioClip coinClip;
    public AudioClip wingClip;
    public AudioClip hitClip;
    public AudioClip dieClip;
    public AudioClip winClip;

    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }

    public void PlayVFX(AudioClip vfxClip)
    {
        vfxAudioSource.clip = vfxClip;
        vfxAudioSource.PlayOneShot(vfxClip);
    }
}


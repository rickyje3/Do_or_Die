using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip song1;
    public AudioClip damage;
    public AudioClip poof;
    public AudioClip teleport;
    public AudioClip dicethrow;
    public AudioClip lose;
    public AudioClip win;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = song1;
        musicSource.Play();
    }

    public void playSFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
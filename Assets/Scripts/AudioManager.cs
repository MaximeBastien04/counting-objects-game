using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip objectFind;
    public AudioClip win;


    public void PlayFindObject() 
    {
        SFXSource.clip = objectFind;
        SFXSource.Play();
    }

    public void PlayWinSound()
    {
        musicSource.clip = win;
        musicSource.Play();
    }
}

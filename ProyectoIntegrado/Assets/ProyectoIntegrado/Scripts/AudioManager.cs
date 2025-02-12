using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SfxSource;

    [Header("Audio Clip")]
    public AudioClip backGround;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip warp;
    public AudioClip boost;
    public AudioClip levelComplete;
    public AudioClip buttonPress;

    void Start()
    {
        musicSource.clip = backGround;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);
    }
}

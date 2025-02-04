using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    // Instancia singleton
    public static AudioManager instance;

    // Audio Sources para efectos y música
    public AudioSource musicSource;
    public AudioSource sfxSource;

    // Lista de clips de música y efectos
    public List<AudioClip> musicClips;
    public List<AudioClip> sfxClips;

    // Indices actuales de la música
    private int currentMusicIndex = 0;

    private void Awake()
    {
        // Verificar si la instancia ya existe
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Reproducir música de fondo
    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musicClips.Count)
        {
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
    }

    // Cambiar la música
    public void ChangeMusic(int index)
    {
        if (index != currentMusicIndex)
        {
            currentMusicIndex = index;
            PlayMusic(currentMusicIndex);
        }
    }

    // Reproducir efectos de sonido
    public void PlaySFX(int index)
    {
        if (index >= 0 && index < sfxClips.Count)
        {
            sfxSource.PlayOneShot(sfxClips[index]);
        }
    }

    // Detener la música
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Ajustar volumen de la música
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // Ajustar volumen de los efectos de sonido
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obtén el componente Audio Source al inicio
        audioSource = GetComponent<AudioSource>();

        // Reproduce la música al inicio
        PlayMusic();
    }

    // Método para reproducir la música
    void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Método para detener la música
    void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

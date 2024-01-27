using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip burbuja1;
    public AudioClip boof;

    void Start()
    {
        // Obtén el componente Audio Source al inicio
        audioSource = GetComponent<AudioSource>();

        // Ajusta el volumen
        audioSource.volume = 0.2f;

        // Reproduce la música al inicio
        audioSource.Play();

        
    }
}

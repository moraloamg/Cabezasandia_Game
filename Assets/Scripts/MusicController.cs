using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip burbuja1;
    public AudioClip boof;
    public AudioClip sonidoClick;


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // Obtén el componente Audio Source al inicio
        audioSource = GetComponent<AudioSource>();

        // Ajusta el volumen
        audioSource.volume = 0.2f;

        audioSource.Stop();
        
    }

}

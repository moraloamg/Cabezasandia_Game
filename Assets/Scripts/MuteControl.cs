using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteControl : MonoBehaviour
{

    private AudioSource audioSource;

    public GameObject iconoMute;
    public GameObject iconoSonando;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // Código a ejecutar cuando se hace clic en el objeto
        string buttonTag = gameObject.tag;

        switch(buttonTag)
        {
            case "BotonMute":
                BotonMute();
                break;
            default:
                break;
        }
        
    }

    private void BotonMute()
    {
        if(audioSource.isPlaying){
            audioSource.Stop();
            iconoMute.SetActive(true);
            iconoSonando.SetActive(false);
        }else{
            audioSource.Play();
            iconoSonando.SetActive(true);
            iconoMute.SetActive(false);
        }
    }
}

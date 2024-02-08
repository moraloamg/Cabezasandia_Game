using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public Sprite imagenNormal;  //Sprite original del botón
    public Sprite imagenResaltada;  //Nuevo sprite al pasar el ratón

    private GameObject botonSalir;

    private SpriteRenderer spriteRenderer;

    public AudioSource audioSource;

    private static int contadorID = 0;
    public int uniqueID;

    //Esto hace que el objeto no se destruya al cargar una nueva escena
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    void Start(){

        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        uniqueID = contadorID;
        contadorID++;

        if(uniqueID > 2 && (this.gameObject.tag == "BotonSalir" || this.gameObject.tag == "BotonStart")){
            Destroy(gameObject);
        }


        //Obtener el componente SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Asegurarse de que se haya asignado un SpriteRenderer y al menos un sprite
        if (spriteRenderer == null || imagenNormal == null || imagenResaltada == null)
        {
            Debug.LogError("Se requiere un SpriteRenderer y sprites asignados.");
            return;
        }

        botonSalir = GameObject.Find("ButtonSalir"); 
                
    }

    void Update()
    {

        //Comprueba si el jugador está en la escena "tutorial"
        if (SceneManager.GetActiveScene().name == "TutorialScene")
        {
            //Comprueba si se ha pulsado la tecla de espacio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Cambia a la escena "Juego"
                SceneManager.LoadScene("MainScene");
                audioSource.Play();
            }
        }

        if (SceneManager.GetActiveScene().name == "MainScene")
        {

            if(GameObject.Find("EndGame").GetComponent<GameOverController>().finDeJuego == true){

                Time.timeScale = 0f;

           
                Renderer rendererCartelGameOver = GameObject.Find("cartel_game_over").GetComponent<Renderer>();
                Renderer rendererBotonSalir2 = GameObject.Find("boton_almenu2").GetComponent<Renderer>();
                Renderer rendererReiniciar = GameObject.Find("boton_reiniciar").GetComponent<Renderer>();

                Collider2D colliderSalir2 = GameObject.Find("boton_almenu2").GetComponent<Collider2D>();
                Collider2D colliderReiniciar = GameObject.Find("boton_reiniciar").GetComponent<Collider2D>();

                TextMeshProUGUI puntuacionFinal = GameObject.Find("Resumen_puntuacion").GetComponent<TextMeshProUGUI>();

                if (rendererCartelGameOver != null && rendererBotonSalir2 != null)
                {
                    rendererCartelGameOver.enabled = true;
                    rendererBotonSalir2.enabled = true;
                    rendererReiniciar.enabled = true;

                    colliderSalir2.enabled = true;
                    colliderReiniciar.enabled = true;

                    puntuacionFinal.enabled = true;
                    puntuacionFinal.text = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;
                }
            }



            //Comprueba si se ha pulsado la tecla escape
            if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("EndGame").GetComponent<GameOverController>().finDeJuego != true)
            {
                Time.timeScale = 0f;

                Renderer rendererCartel = GameObject.Find("cartel_salir").GetComponent<Renderer>();
                Renderer rendererBotonSeguir = GameObject.Find("boton_seguir").GetComponent<Renderer>();
                Renderer rendererBotonSalir = GameObject.Find("boton_almenu").GetComponent<Renderer>();

                Collider2D colliderSeguir = GameObject.Find("boton_seguir").GetComponent<Collider2D>();
                Collider2D colliderSalir = GameObject.Find("boton_almenu").GetComponent<Collider2D>();

                if (rendererCartel != null && rendererBotonSeguir != null && rendererBotonSalir != null)
                {
                    rendererCartel.enabled = true;
                    rendererBotonSeguir.enabled = true;
                    rendererBotonSalir.enabled = true;

                    colliderSeguir.enabled = true;
                    colliderSalir.enabled = true;
                }
            }
        }
    }
    

    //Al pasar el ratón sobre el botón
    void OnMouseEnter()
    {
        //Cambia el sprite al resaltado
        spriteRenderer.sprite = imagenResaltada;
    }

    //Al salir del ratón del botón
    void OnMouseExit()
    {
        //Vuelve al sprite normal
        spriteRenderer.sprite = imagenNormal;
    }

    //Al pulsar con el raton sobre el botón
    void OnMouseDown()
    {
        //Código a ejecutar cuando se hace clic en el objeto
        string buttonTag = gameObject.tag;

        switch(buttonTag)
        {
            case "BotonStart":
                BotonStart();
                break;
            case "BotonSalir":
                BotonSalir();
                break;
            case "BotonAlMenu":
                BotonAlMenu();
                break;
            case "BotonAlMenu2":
                BotonAlMenu2();
                break;
            case "BotonReiniciar":
                BotonReiniciar();
                break;
            case "BotonSeguir":
                BotonSeguir();
                break;
            default:
                break;
        }
        
    }

    private void BotonReiniciar()
    {
        audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().sonidoClick);

        GameObject.Find("EndGame").GetComponent<GameOverController>().finDeJuego = false;
        Time.timeScale = 1f;
        audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }

    private void BotonAlMenu2()
    {
        audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().sonidoClick);
        
        Renderer rendererCartelGameOver = GameObject.Find("cartel_game_over").GetComponent<Renderer>();
        Renderer rendererBotonSalir2 = GameObject.Find("boton_almenu2").GetComponent<Renderer>();
        Renderer rendererBotonReiniciar = GameObject.Find("boton_reiniciar").GetComponent<Renderer>();

        Collider2D colliderSalir2 = GameObject.Find("boton_almenu2").GetComponent<Collider2D>();
        Collider2D colliderReiniciar = GameObject.Find("boton_almenu2").GetComponent<Collider2D>();

        TextMeshProUGUI puntuacionFinal = GameObject.Find("Resumen_puntuacion").GetComponent<TextMeshProUGUI>();

        if (rendererCartelGameOver != null && rendererBotonSalir2 != null)
        {
            rendererCartelGameOver.enabled = false;
            rendererBotonSalir2.enabled = false;
            rendererBotonReiniciar.enabled = false;

            colliderSalir2.enabled = false;
            colliderReiniciar.enabled = false;

            puntuacionFinal.enabled = false;

            GameObject.Find("EndGame").GetComponent<GameOverController>().finDeJuego = false;
        }

        Renderer rendererSalirJuego = GameObject.Find("ButtonSalir").GetComponent<Renderer>();
        Collider2D colliderSalirJuego = GameObject.Find("ButtonSalir").GetComponent<Collider2D>();
        if (rendererSalirJuego != null && colliderSalirJuego != null)
        {
            rendererSalirJuego.enabled = true;
            colliderSalirJuego.enabled = true;
        }


        Renderer rendererStart = GameObject.Find("ButtonStart").GetComponent<Renderer>();
        Collider2D colliderStart = GameObject.Find("ButtonStart").GetComponent<Collider2D>();
        if (rendererStart != null && colliderStart != null)
        {
            rendererStart.enabled = true;
            spriteRenderer.sprite = imagenNormal; // no rula
            colliderStart.enabled = true;
        }

        audioSource.Stop();
        SceneManager.LoadScene("MenuScene");

        Time.timeScale = 1f;
    }

    private void BotonSeguir()
    {
        audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().sonidoClick);
        Time.timeScale = 1f;

        Renderer rendererCartel = GameObject.Find("cartel_salir").GetComponent<Renderer>();
        Renderer rendererBotonSeguir = GameObject.Find("boton_seguir").GetComponent<Renderer>();
        Renderer rendererBotonSalir = GameObject.Find("boton_almenu").GetComponent<Renderer>();

        Collider2D colliderSeguir = GameObject.Find("boton_seguir").GetComponent<Collider2D>();
        Collider2D colliderSalir = GameObject.Find("boton_almenu").GetComponent<Collider2D>();

        if (rendererCartel != null && rendererBotonSeguir != null && rendererBotonSalir != null)
        {
            rendererCartel.enabled = false;
            rendererBotonSeguir.enabled = false;
            rendererBotonSalir.enabled = false;

            colliderSeguir.enabled = false;
            colliderSalir.enabled = false;
        }

    }

    private void BotonAlMenu()
    {
        audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().sonidoClick);

        Renderer rendererCartel = GameObject.Find("cartel_salir").GetComponent<Renderer>();
        Renderer rendererBotonSeguir = GameObject.Find("boton_seguir").GetComponent<Renderer>();
        Renderer rendererBotonSalir = GameObject.Find("boton_almenu").GetComponent<Renderer>();

        Collider2D colliderSeguir = GameObject.Find("boton_seguir").GetComponent<Collider2D>();
        Collider2D colliderSalir = GameObject.Find("boton_almenu").GetComponent<Collider2D>();

        if (rendererCartel != null && rendererBotonSeguir != null && rendererBotonSalir != null)
        {
            rendererCartel.enabled = false;
            rendererBotonSeguir.enabled = false;
            rendererBotonSalir.enabled = false;

            colliderSeguir.enabled = false;
            colliderSalir.enabled = false;
        }
        
        
        Renderer rendererSalirJuego = GameObject.Find("ButtonSalir").GetComponent<Renderer>();
        Collider2D colliderSalirJuego = GameObject.Find("ButtonSalir").GetComponent<Collider2D>();
        if (rendererSalirJuego != null && colliderSalirJuego != null)
        {
            rendererSalirJuego.enabled = true;
            colliderSalirJuego.enabled = true;
        }

        Renderer rendererStart = GameObject.Find("ButtonStart").GetComponent<Renderer>();
        Collider2D colliderStart = GameObject.Find("ButtonStart").GetComponent<Collider2D>();
        if (rendererStart != null && colliderStart != null)
        {
            rendererStart.enabled = true;
            spriteRenderer.sprite = imagenNormal; //no rula
            colliderStart.enabled = true;
        }

        audioSource.Stop();
        SceneManager.LoadScene("MenuScene");

        Time.timeScale = 1f;

    }

    void BotonStart()
    {
        audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().sonidoClick);
	    //Cambia a la MainScene
        SceneManager.LoadScene("TutorialScene");

        //Desactivar el componente Renderer
        Renderer renderer = GetComponent<Renderer>();
        Renderer renderer2 = botonSalir.GetComponent<Renderer>();

        Collider2D collider = GetComponent<Collider2D>();
        Collider2D collider2 = botonSalir.GetComponent<Collider2D>();

        if (renderer != null && renderer2 != null)
        {
            renderer.enabled = false;
            renderer2.enabled = false;

            collider.enabled = false;
            collider2.enabled = false;
        }
    }

    void BotonSalir()
    {
        audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().sonidoClick);
	    //Cierra la aplicación o juego
        Debug.Log("Has salido");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public Sprite imagenNormal;  // Sprite original del botón
    public Sprite imagenResaltada;  // Nuevo sprite al pasar el ratón

    private SpriteRenderer spriteRenderer;


    void Start(){
        // Obtén el componente SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Asegúrate de que se haya asignado un SpriteRenderer y al menos un sprite
        if (spriteRenderer == null || imagenNormal == null || imagenResaltada == null)
        {
            Debug.LogError("Se requiere un SpriteRenderer y sprites asignados.");
            return;
        }

        // Establece el sprite normal al inicio
        spriteRenderer.sprite = imagenNormal;
    }

    // Al pasar el ratón sobre el botón
    void OnMouseEnter()
    {
        // Cambia el sprite al resaltado
        spriteRenderer.sprite = imagenResaltada;
    }

    // Al salir del ratón del botón
    void OnMouseExit()
    {
        // Vuelve al sprite normal
        spriteRenderer.sprite = imagenNormal;
    }

    // Al pulsar con el raton sobre el botón
    void OnMouseDown()
    {
        // Código a ejecutar cuando se hace clic en el objeto
	    string buttonTag = gameObject.tag;

        switch(buttonTag)
        {
            case "BotonStart":
                BotonStart();
                break;
            case "BotonCreditos":
                BotonCreditos();
                break;
            case "BotonSalir":
                BotonSalir();
                break;
            default:
                break;
        }		
    }

    void BotonStart()
    {
	    // Cambia a la MainScene
        SceneManager.LoadScene("MainScene");
    }

    void BotonCreditos()
    {
	    // Cambia a la CreditsScene
        SceneManager.LoadScene("CreditsScene");
    }

    void BotonSalir()
    {
	    // Cierra la aplicación o juego
        Application.Quit();
    }
}

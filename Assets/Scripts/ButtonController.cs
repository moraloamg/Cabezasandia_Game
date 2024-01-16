using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    //public GameObject gameObject;

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
        SceneManager.LoadScene("TutorialScene");
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

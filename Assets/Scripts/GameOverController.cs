using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
 
    private bool isColliding = false;
    private float collisionTime = 0f;
    private float requiredCollisionTime = 1.5f;

    public bool finDeJuego = false;

    void Update()
    {

        // Verificar si la colisión ha estado ocurriendo durante el tiempo requerido
        if (isColliding)
        {
            collisionTime += Time.deltaTime;

            if (collisionTime >= requiredCollisionTime)
            {
                Debug.Log("¡Hola! La colisión ha durado al menos 1.5 segundos.");
		        StartCoroutine(Parpadear());
                // Aquí puedes realizar otras acciones que desees

		        collisionTime = 0f;

                finDeJuego = true;  

            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Verificar si la colisión es con el objeto que te interesa
        if (collider.gameObject.tag == "Frutem")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Restablecer el estado si la colisión termina
        if (collider.gameObject.tag == "Frutem")
        {
            isColliding = false;
            collisionTime = 0f;
        }
    }

    IEnumerator Parpadear()
    {
        Renderer renderer = GetComponent<Renderer>();

	    // El bucle sirve para hacer que el objeto parpadee
        while (true)
        {
            // Invertir la visibilidad (activar/desactivar)
            renderer.enabled = !renderer.enabled;

            // Esperar 0.5 segundos
            yield return new WaitForSeconds(0.5f);
        }
    }
}

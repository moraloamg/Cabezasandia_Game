using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    //creamos el objeto que nos comunicara con el gameController
    public GameController gameController; 

    void Start()
    {
        //instanciamos el objeto gameController, es necesario encontrar el objeto (en el escenario) y su componente
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Estado del gameController: "+gameController.libre);

        // Verifica si la colisión involucra a otro objeto del mismo tipo y si el
        // gameController no esta ocupado creando una fruta, porque como no comprobemos que el otro este libre
        // este se nos adelanta y hace cosas raras
        if (collision.gameObject.name == gameObject.name && gameController.libre == true)
        {
            //Debug.Log("Manejando colisión de "+gameObject.name+" con id "+gameObject.GetInstanceID()+" con la fruta "+collision.gameObject.name+" con id "+collision.gameObject.GetInstanceID());

            //obtenemos el vector de coordenadas 
            Vector2 posicionColision = collision.contacts[0].point;
            Vector2 centroObjetoColisionado = collision.collider.bounds.center;
            Vector2 puntoMedio = (posicionColision + centroObjetoColisionado) / 2f;

            //Debug.Log("Llamada a gameController con "+gameObject.name);
            //llamamos al gameController para que se encarge de generar la fruta, en base al tipo de ellas que han
            //colisionado y su posicion
            gameController.generarFrutas(puntoMedio, gameObject, collision.gameObject);
	    }
    }
}

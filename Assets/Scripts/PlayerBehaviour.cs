using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public List<GameObject> objetosAleatorios;
    private GameObject objetoGenerado, objetoSiguiente;
    UnityEngine.UI.Image imagenSiguienteFruta;
    private bool teclaEspacioHabilitada = true;
    
    public float limiteDerecho = 8.5f;
    public float limiteIzquierdo = -8.5f;

    void Start() {
        imagenSiguienteFruta = GameObject.Find("ImageSiguienteFruta").GetComponent<UnityEngine.UI.Image>();
	    InstanciarFrutaAleatoria();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0f);

        // Calcula la nueva posición con límites
        float newPositionX = Mathf.Clamp(transform.position.x + movimiento.x * velocidad * Time.deltaTime, limiteIzquierdo, limiteDerecho);  

        // Aplica la nueva posición
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);  

        // Verificar si la tecla espacio ha sido presionada
        if (teclaEspacioHabilitada && Input.GetKeyDown(KeyCode.Space) && objetoGenerado != null)
        {
            // Comprobar tecla para poder inhabilitarla durante un segundo
            teclaEspacioHabilitada = false;

            // Activar el Collider
	        objetoGenerado.GetComponent<Collider2D>().enabled = true;

            // Detener el seguimiento del objeto generado al objeto principal
            objetoGenerado.transform.parent = null;
	    
            // Activa la gravedad
            objetoGenerado.GetComponent<Rigidbody2D>().gravityScale = 1f;

	        // Generar fruta aleatoria después de 1.5 segundos
	        StartCoroutine(GenerarFrutaConRetardo());

            // Llamar a un método para habilitar la tecla espacio después de 1.5 segundos
            StartCoroutine(HabilitarTeclaEspacio());
         }
    }

    private IEnumerator HabilitarTeclaEspacio()
    {

        // Esperar 1.5 segundos
        yield return new WaitForSeconds(1.5f);

        // Generar fruta
        teclaEspacioHabilitada=true;
    }

    public void InstanciarFrutaAleatoria()
    {
        
        if (objetosAleatorios.Count > 0)
        {
            // Obtener posición debajo del objeto actual
            Vector2 posicionDebajo = new Vector2(transform.position.x, transform.position.y - 1f);

            //si es la primera vez que se inicia el juego, en que ambos estan a null, ambos se generan de manera aleatoria
            if(objetoSiguiente == null && objetoGenerado == null){

                // Seleccionar un objeto aleatorio de la lista
                objetoSiguiente = objetosAleatorios[Random.Range(0, objetosAleatorios.Count)];
                imagenSiguienteFruta.sprite = objetoSiguiente.GetComponent<SpriteRenderer>().sprite;

                objetoGenerado = objetosAleatorios[Random.Range(0, objetosAleatorios.Count)];
            }else{
          
                //cargamos el siguiente objeto
                objetoGenerado = objetoSiguiente;

                // Seleccionar un objeto aleatorio de la lista
                objetoSiguiente = objetosAleatorios[Random.Range(0, objetosAleatorios.Count)];
                imagenSiguienteFruta.sprite = objetoSiguiente.GetComponent<SpriteRenderer>().sprite;
            }

            // Instanciar el objeto en la posición debajo
            objetoGenerado = Instantiate(objetoGenerado, posicionDebajo, Quaternion.identity);

            // Establecer el objeto generado como hijo del objeto principal para seguirlo
            objetoGenerado.transform.parent = transform;           
        }
    }

    private IEnumerator GenerarFrutaConRetardo()
    {

        // Esperar 1.5 segundos
        yield return new WaitForSeconds(1.5f);

        // Generar fruta
        InstanciarFrutaAleatoria();
    }
}

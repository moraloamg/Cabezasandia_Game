using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class GameController : MonoBehaviour
{

    public GameObject frutaGenerada;
    public List<GameObject> listaFrutems;
    public bool libre = true;

    public TextMeshProUGUI scoreText;
    public int score = 0;

    public AudioSource audioSource;

    void Start()
    {
        //inicializamos el componente
        scoreText = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        // Puntuación que se mostrará en el TextMeshProUGUI
        scoreText.text = score.ToString();

        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }
    

    //funcion que recibe la llamada
    public void generarFrutas(Vector2 puntoMedio, GameObject frutaOriginal, GameObject frutaColision)
    {
        //aqui el game controller empieza a trabajar, ponemos libre a false para que el script
        //de frutas no se adelande o haga cosas raras, que la programacion multihilo tiene esa mania
        libre = false;
        //llamamos a la rutina para destruir la fruta (no queda otro remedio)
        StartCoroutine(destruirFrutas(puntoMedio, frutaOriginal, frutaColision));
    }


    IEnumerator destruirFrutas(Vector2 puntoMedio, GameObject frutaOriginal, GameObject frutaColision)
    {
        //obtenemos los nombre de las frutas para comprobar su tipo y combinacion mas adelante
        //ya que ahora se van a destruir
        string nombreFrutaOrigen = frutaOriginal.name;
        string nombreFrutaColision = frutaColision.name;

        //destruimos las frutas y esperamos con el yield return a que se destruyan bien destruidas
        Destroy(frutaOriginal);
        Destroy(frutaColision);

        yield return new WaitUntil(() => frutaOriginal == null && frutaColision == null);

        //Debug.Log("Ambas frutas destruidas");

        //ahora llamamos al controlador de frutas para generar la fruta pertinente con los datos que
        //hemos recogido
        controladorFrutas(puntoMedio, nombreFrutaOrigen, nombreFrutaColision);
    }

    private void controladorFrutas(Vector2 puntoMedio, string frutaOriginal, string frutaColision){
        
        //Dentro de estos if iria el sonido y (si hay) la animación
        //con ifs comprobamos los datos de la combinacion y generamos la fruta pertinente
        if(frutaOriginal == "Fresa(Clone)" && frutaColision == "Fresa(Clone)"){
            //Debug.Log("Generando un coco");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[1], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(2);
        }
        if(frutaOriginal == "Coco(Clone)" && frutaColision == "Coco(Clone)"){
            //Debug.Log("Generando in kiwi");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[2], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID()); 
	        IncrementarScore(4);
        }
	    if(frutaOriginal == "Kiwi(Clone)" && frutaColision == "Kiwi(Clone)"){
            //Debug.Log("Generando un platano");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[3], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(8);
        }
	    if(frutaOriginal == "Platano(Clone)" && frutaColision == "Platano(Clone)"){
            //Debug.Log("Generando una naranja");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[4], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());       
	        IncrementarScore(16);
        }
	    if(frutaOriginal == "Naranja(Clone)" && frutaColision == "Naranja(Clone)"){
            //Debug.Log("Generando una manzana");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[5], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(32);
        }
	    if(frutaOriginal == "Manzana(Clone)" && frutaColision == "Manzana(Clone)"){
            //Debug.Log("Generando un melocoton");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[6], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(64);
        }
	    if(frutaOriginal == "Melocoton(Clone)" && frutaColision == "Melocoton(Clone)"){
            //Debug.Log("Generando una piña");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[7], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(128);
        }
	    if(frutaOriginal == "Piña(Clone)" && frutaColision == "Piña(Clone)"){
            //Debug.Log("Generando una pera");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[8], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(256);
        }
	    if(frutaOriginal == "Pera(Clone)" && frutaColision == "Pera(Clone)"){
            //Debug.Log("Generando una sandia");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().boof);
            frutaGenerada = Instantiate(listaFrutems[9], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(512);
        }
	    if(frutaOriginal == "Sandia(Clone)" && frutaColision == "Sandia(Clone)"){
            //Debug.Log("Generando una fresa");
            audioSource.PlayOneShot(audioSource.GetComponent<MusicController>().burbuja1);
            frutaGenerada = Instantiate(listaFrutems[0], puntoMedio, Quaternion.identity);
            frutaGenerada.GetComponent<Collider2D>().enabled = true;
            frutaGenerada.GetComponent<Rigidbody2D>().gravityScale = 1f;
            //Debug.Log("Generada una "+frutaGenerada.name+" con ID"+frutaGenerada.GetInstanceID());
	        IncrementarScore(512);
        }
        //notifcamos que el gameController esta libre de tareas por si se detecta otra colision
        libre = true;
        //Debug.Log("Game controler libre");
    }

    public void IncrementarScore(int entradaScore)
    {
        //Debug.Log("Entrada: "+ entradaScore);
        this.score += entradaScore;
        scoreText.text = score.ToString();
        //Debug.Log("Score actual:"+this.score);
    }


    

}

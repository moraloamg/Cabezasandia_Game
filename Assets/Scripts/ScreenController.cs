using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Al pulsar espacio carga el juego
	if (Input.GetKeyDown(KeyCode.Space))
	{
	    SceneManager.LoadScene("MainScene");
	}
    }
}

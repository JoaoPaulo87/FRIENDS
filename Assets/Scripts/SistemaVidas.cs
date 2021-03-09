using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SistemaVidas : MonoBehaviour
{
    public Image corazon;
    public int cantDeCorazones;
    public RectTransform posicionPrimerCorazon;
    public Canvas myCanvas;
    public int offsetCorazon;

    void Start()
    {
        // Esto es para que cree tantos corazones como le ponemos en la variable cantDeCorazones.
        Transform posCorazon = posicionPrimerCorazon;

        for (int i = 0; i < cantDeCorazones; i++)
        {
            Image newCorazon = Instantiate(corazon, posCorazon.position, Quaternion.identity);
            newCorazon.transform.parent = myCanvas.transform;
            posCorazon.position = new Vector2(posCorazon.position.x + offsetCorazon, posCorazon.position.y);
        }
    }
    void Update()
    {
        PerderJuego();
    }

    // Cuando el jugador colisiona con un mono, pierde una vida.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Serpiente")
        {
            PerderVida();
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void PerderJuego()
    {
        //Si tenemos 0 cantidad de corazones, perdemos y se recarga la pantalla.
        if (cantDeCorazones < 1)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void PerderVida()
    {
        Destroy(myCanvas.transform.GetChild(cantDeCorazones + 1).gameObject);
        cantDeCorazones -= 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicaOnOff : MonoBehaviour
{
    private GameObject m_musicaNivel;
    private GameObject[] m_sonidoFuego;
    private GameObject[] m_sonidoViboras;
    private GameObject[] m_sonidoBanana;
    private GameObject[] m_sonidoEstrellas;
    private GameObject[] m_sonidoCharcos;

    void Start()
    {
        this.m_musicaNivel = GameObject.FindGameObjectWithTag("Musica");
        this.m_sonidoViboras = GameObject.FindGameObjectsWithTag("Serpiente");
        this.m_sonidoFuego = GameObject.FindGameObjectsWithTag("Fuego");
        this.m_sonidoBanana = GameObject.FindGameObjectsWithTag("Banana");
        this.m_sonidoEstrellas = GameObject.FindGameObjectsWithTag("Estrella");
        this.m_sonidoCharcos = GameObject.FindGameObjectsWithTag("Charco");
    }

    public void PonerOnMusica()
    {
        this.m_musicaNivel.GetComponent<AudioSource>().Play();
    }

    public void PonerOffMusica()
    {
        this.m_musicaNivel.GetComponent<AudioSource>().Pause();
    }

    public void PonerOnSonido()
    {
        foreach (GameObject audio in this.m_sonidoViboras)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0.386f;
        }

        foreach (GameObject audio in this.m_sonidoFuego)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0.386f;
        }

        foreach (GameObject audio in this.m_sonidoBanana)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0.386f;
        }

        foreach (GameObject audio in this.m_sonidoEstrellas)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0.386f;
        }

        foreach (GameObject audio in this.m_sonidoCharcos)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0.386f;
        }
    }

    public void PonerOffSonido()
    {
        foreach (GameObject audio in this.m_sonidoViboras)
        {
            audio.GetComponent<AudioSource>().volume = 0f;
        }

        foreach (GameObject audio in this.m_sonidoFuego)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0f;
        }

        foreach (GameObject audio in this.m_sonidoBanana)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0f;
        }

        foreach (GameObject audio in this.m_sonidoEstrellas)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0f;
        }

        foreach (GameObject audio in this.m_sonidoCharcos)
        {
            audio.gameObject.GetComponent<AudioSource>().volume = 0f;
        }
    }
}

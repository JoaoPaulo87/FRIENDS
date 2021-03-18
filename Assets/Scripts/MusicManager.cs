using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource m_musicaMainMenu;
    public AudioSource m_musicaPrimerNivel;
    public AudioSource m_musicaGanar;
    public AudioSource m_musicaPerder;

    public void MusicaMainMenuOn()
    {
        this.m_musicaMainMenu.Play();
    }

    public void MusicaMainMenuOff()
    {
        this.m_musicaMainMenu.Pause();
    }

    public void MusicaPrimerNivelOn()
    {
        this.m_musicaPrimerNivel.Play();
    }

    public void MusicaPrimerNivelOff()
    {
        this.m_musicaPrimerNivel.Pause();
    }

    public void MusicaGanarOn()
    {
        this.m_musicaGanar.Play();
    }

    public void MusicaGanarOff()
    {
        this.m_musicaGanar.Pause();
    }

    public void MusicaPerderOn()
    {
        this.m_musicaPerder.Play();
    }

    public void MusicaPerderOff()
    {
        this.m_musicaPerder.Pause();
    }
}

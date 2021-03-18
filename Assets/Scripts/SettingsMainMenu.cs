using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMainMenu : MonoBehaviour
{
    [SerializeField] private Button m_botonVolver;
    [SerializeField] private Button m_botonSonido;
    [SerializeField] private Button m_botonMusica;

    [SerializeField] private MusicaOnOff m_musicaOnOff;

    [SerializeField] private Sprite m_spriteOn;
    [SerializeField] private Sprite m_spriteOff;

    private bool isMusicaOn;
    private bool isSonidoOn;

    private void Start()
    {
        this.isMusicaOn = false;
        this.isSonidoOn = false;

        m_botonVolver.GetComponent<Button>();
        m_botonMusica.GetComponent<Button>();
        m_botonSonido.GetComponent<Button>();
        m_musicaOnOff.GetComponent<MusicaOnOff>();

        this.m_botonSonido.GetComponent<Image>().sprite = this.m_spriteOn;
        this.m_botonMusica.GetComponent<Image>().sprite = this.m_spriteOn;
    }

    public void Volver()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PrenderApagarMusica()
    {
        if (this.isMusicaOn)
        {
            MusicaOff();
        }
        else
        {
            MusicaOn();
        }
    }

    public void PrenderApagarSonido()
    {
        if (this.isSonidoOn)
        {
            SonidoOff();
        }
        else
        {
            SonidoOn();
        }
    }

    private void MusicaOn()
    {
        this.m_botonMusica.image.overrideSprite = this.m_spriteOff;
        this.isMusicaOn = true;
        this.m_musicaOnOff.PonerOffMusica();
    }

    private void MusicaOff()
    {
        this.m_botonMusica.image.overrideSprite = this.m_spriteOn;
        this.isMusicaOn = false;
        this.m_musicaOnOff.PonerOnMusica();
    }

    private void SonidoOn()
    {
        this.m_botonSonido.image.overrideSprite = this.m_spriteOff;
        this.isSonidoOn = true;
        this.m_musicaOnOff.PonerOffSonido();
    }

    private void SonidoOff()
    {
        this.m_botonSonido.image.overrideSprite = this.m_spriteOn;
        this.isSonidoOn = false;
        this.m_musicaOnOff.PonerOnSonido();
    }
}

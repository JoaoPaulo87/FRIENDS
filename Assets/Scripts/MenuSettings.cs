using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private Button m_botonVolver;
    [SerializeField] private Button m_botonSonido;
    [SerializeField] private Button m_botonMusica;

    [SerializeField] private Canvas m_menuSettings;
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

        this.m_menuSettings.gameObject.SetActive(false);

        this.m_botonSonido.GetComponent<Image>().sprite = this.m_spriteOn;
        this.m_botonMusica.GetComponent<Image>().sprite = this.m_spriteOn;
    }

    public void Volver()
    {
        Time.timeScale = 1f;
        this.m_menuSettings.gameObject.SetActive(false);
    }

    public void AbrirMenuSettings()
    {
        this.m_menuSettings.gameObject.SetActive(true);
        Time.timeScale = 0f;
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

    public void MusicaOn()
    {
        this.m_botonMusica.image.overrideSprite = this.m_spriteOff;
        this.isMusicaOn = true;
        this.m_musicaOnOff.PonerOffMusica();
    }

    public void MusicaOff()
    {
        this.m_botonMusica.image.overrideSprite = this.m_spriteOn;
        this.isMusicaOn = false;
        this.m_musicaOnOff.PonerOnMusica();
    }

    public void SonidoOn()
    {
        this.m_botonSonido.image.overrideSprite = this.m_spriteOff;
        this.isSonidoOn = true;
        this.m_musicaOnOff.PonerOffSonido();
    }

    public void SonidoOff()
    {
        this.m_botonSonido.image.overrideSprite = this.m_spriteOn;
        this.isSonidoOn = false;
        this.m_musicaOnOff.PonerOnSonido();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private bool isPausado = true;

    [SerializeField] private Button m_BotonPausa;
    [SerializeField] private Button m_BotonVolver;
    [SerializeField] private Button m_BotonSalirAlMenu;
    [SerializeField] private Button m_BotonReiniciar;

    [SerializeField] private Canvas m_menuPausa;

    void Start()
    {
        Button btnPausa = m_BotonPausa.GetComponent<Button>();
        Button btnVolver = m_BotonVolver.GetComponent<Button>();
        Button btnSalir = m_BotonSalirAlMenu.GetComponent<Button>();
        Button btnReiniciar = m_BotonReiniciar.GetComponent<Button>();

        btnPausa.onClick.AddListener(Pausa);
        btnVolver.onClick.AddListener(DesPausar);
        btnSalir.onClick.AddListener(VolverMenuPrincipal);
        btnReiniciar.onClick.AddListener(ReiniciarNivel);

        this.m_menuPausa.gameObject.SetActive(false);
    }

    public void Pausa()
    {
        if (!this.isPausado)
        {
            DesPausar();
        }
        else
        {
            this.m_menuPausa.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void DesPausar()
    {
        Time.timeScale = 1f;
        this.m_menuPausa.gameObject.SetActive(false);
    }

    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}

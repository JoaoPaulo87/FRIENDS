using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private Button m_botonVolver;
    [SerializeField] private Button m_botonSettings;

    [SerializeField] private Canvas m_menuSettings;

    private void Start()
    {
        Button btnVolver = m_botonVolver.GetComponent<Button>();

        btnVolver.onClick.AddListener(Volver);

        this.m_menuSettings.gameObject.SetActive(false);
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
}

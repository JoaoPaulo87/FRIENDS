using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElegirFrutaDelBoss : MonoBehaviour
{
    public Animator bossAnimator;
    public Animator amigoAnimator;

    public Button botonOpcion1;
    public Button botonOpcion2;
    public Button botonOpcion3;

    public Button botonReintentar;
    public Button botonContinuar;
    public Button botonSalir;

    public Sprite spritePanelBasico;
    public Sprite spritePanelRtaCorrecta;
    public Sprite spritePanelRtaIncorrecta;

    public Sprite spriteOpcion1Incorrecta;
    public Sprite spriteOpcion2Incorrecta;
    public Sprite spriteOpcion3Correcta;

    public Sprite spriteOpcion1;
    public Sprite spriteOpcion2;
    public Sprite spriteOpcion3;

    private SpriteRenderer panelOpciones;

    [SerializeField] private Canvas m_menuSiguienteNivel;

    [SerializeField] private AudioSource m_musicaGanar;
    [SerializeField] private AudioSource m_musicaPerder;
    [SerializeField] private AudioSource m_musicaPrimerNivelFondo;

    private bool isOpcion1Seleccionada = false;

    void Start()
    {
        // we are accessing the SpriteRenderer that is attached to the Gameobject
        this.panelOpciones = GetComponent<SpriteRenderer>();

        Button btn1 = this.botonOpcion1.GetComponent<Button>();
        Button btn2 = this.botonOpcion2.GetComponent<Button>();
        Button btn3 = this.botonOpcion3.GetComponent<Button>();

        btn1.onClick.AddListener(PrimerBotonOnClick);
        btn2.onClick.AddListener(SegundoBotonOnClick);
        btn3.onClick.AddListener(TercerBotonOnClick);

        Button btnRei = this.botonReintentar.GetComponent<Button>();
        Button btnCon = this.botonContinuar.GetComponent<Button>();
        Button btnSal = this.botonSalir.GetComponent<Button>();

        btnRei.onClick.AddListener(ReintentarBotonOnClick);
        btnCon.onClick.AddListener(ContinuarBotonOnClick);
        btnSal.onClick.AddListener(SalirBotonOnClick);

        this.botonReintentar.gameObject.SetActive(false);
        this.botonContinuar.gameObject.SetActive(false);
        this.botonSalir.gameObject.SetActive(false);

        // if the sprite on panelOpciones is null then
        if (this.panelOpciones.sprite == null)
        {
            // set the sprite to spritePanelBasico
            this.panelOpciones.sprite = this.spritePanelBasico;
        }

        this.m_menuSiguienteNivel.gameObject.SetActive(false);
    }

    void PrimerBotonOnClick()
    {
        this.isOpcion1Seleccionada = true;
        StartCoroutine(EligeRtaIncorrecta()); // call method to change sprite
    }
    void SegundoBotonOnClick()
    {
        this.isOpcion1Seleccionada = false;
        StartCoroutine(EligeRtaIncorrecta()); // call method to change sprite
    }

    void TercerBotonOnClick()
    {
        StartCoroutine(EligeRtaCorrecta()); // call method to change sprite
    }

    void ReintentarBotonOnClick()
    {
        SceneManager.LoadScene("PrimerNivel");
    }

    void ContinuarBotonOnClick()
    {
        Time.timeScale = 0f;
        this.m_menuSiguienteNivel.gameObject.SetActive(true);
    }

    void SalirBotonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator EligeRtaIncorrecta()
    {
        if (this.panelOpciones.sprite == this.spritePanelBasico)
        {
            if (this.isOpcion1Seleccionada)
            {
                this.botonOpcion1.image.overrideSprite = this.spriteOpcion1Incorrecta;
            }
            else
            {
                this.botonOpcion2.GetComponent<Image>().sprite = this.spriteOpcion2Incorrecta;
            }

            yield return new WaitForSeconds(3);

            this.panelOpciones.sprite = this.spritePanelRtaIncorrecta;

            this.botonOpcion1.gameObject.SetActive(false);
            this.botonOpcion2.gameObject.SetActive(false);
            this.botonOpcion3.gameObject.SetActive(false);

            if (this.panelOpciones.sprite == this.spritePanelRtaIncorrecta)
            {
                this.botonReintentar.gameObject.SetActive(true);
                this.botonSalir.gameObject.SetActive(true);

                this.bossAnimator.SetBool("IsBossIdle", true);
                this.bossAnimator.SetBool("IsBossSide", false);

                this.m_musicaPrimerNivelFondo.Stop();
                this.m_musicaPerder.Play();
            }
        }
        else
        {
            this.panelOpciones.sprite = this.spritePanelBasico;
        }
    }

    IEnumerator EligeRtaCorrecta()
    {
        if (this.panelOpciones.sprite == this.spritePanelBasico)
        {
            this.botonOpcion3.GetComponent<Image>().sprite = this.spriteOpcion3Correcta;

            yield return new WaitForSeconds(3);

            this.panelOpciones.sprite = this.spritePanelRtaCorrecta;

            this.botonOpcion1.gameObject.SetActive(false);
            this.botonOpcion2.gameObject.SetActive(false);
            this.botonOpcion3.gameObject.SetActive(false);

            if (this.panelOpciones.sprite == this.spritePanelRtaCorrecta)
            {
                this.botonContinuar.gameObject.SetActive(true);

                this.bossAnimator.SetBool("IsBossHappy", true);
                this.amigoAnimator.SetBool("IsAmigoFestejando", true);

                this.m_musicaGanar.Play();
            }
        }
        else
        {
            this.panelOpciones.sprite = this.spritePanelBasico;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.bossAnimator.SetBool("IsBossSide", true);
        }
    }
}
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

    public Sprite spritePanelBasico; // Drag your first sprite here
    public Sprite spritePanelRespuestas; // Drag your second sprite here
    public Sprite spritePanelRtaCorrecta; // Drag your second sprite here
    public Sprite spritePanelRtaIncorrecta; // Drag your second sprite here
    public Sprite spriteOpcion1Incorrecta; // Drag your second sprite here

    private SpriteRenderer panelOpciones;

    void Start()
    {
        // we are accessing the SpriteRenderer that is attached to the Gameobject
        panelOpciones = GetComponent<SpriteRenderer>(); 

        Button btn1 = botonOpcion1.GetComponent<Button>();
        Button btn2 = botonOpcion2.GetComponent<Button>();
        Button btn3 = botonOpcion3.GetComponent<Button>();
        Button btnRei = botonReintentar.GetComponent<Button>();
        Button btnCon = botonContinuar.GetComponent<Button>();
        Button btnSal = botonSalir.GetComponent<Button>();

        btn1.onClick.AddListener(PrimerBotonOnClick);
        btn2.onClick.AddListener(SegundoBotonOnClick);
        btn3.onClick.AddListener(TercerBotonOnClick);
        btnRei.onClick.AddListener(ReintentarBotonOnClick);
        btnCon.onClick.AddListener(ContinuarBotonOnClick);
        btnSal.onClick.AddListener(SalirBotonOnClick);

        this.botonReintentar.gameObject.SetActive(false);
        this.botonContinuar.gameObject.SetActive(false);
        this.botonSalir.gameObject.SetActive(false);

        // if the sprite on spriteRenderer is null then
        if (panelOpciones.sprite == null)
        {
            // set the sprite to sprite1
            panelOpciones.sprite = spritePanelBasico;
        }
    }

    void PrimerBotonOnClick()
    {
        StartCoroutine(EligeRtaIncorrecta()); // call method to change sprite
    }
    void SegundoBotonOnClick()
    {
        StartCoroutine(EligeRtaIncorrecta()); // call method to change sprite
    }

    void TercerBotonOnClick()
    {
        StartCoroutine(EligeRtaCorrecta()); // call method to change sprite
    }

    void ReintentarBotonOnClick()
    {
        SceneManager.LoadScene(1);
    }

    void ContinuarBotonOnClick()
    {
        SceneManager.LoadScene(1);
    }

    void SalirBotonOnClick()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator EligeRtaIncorrecta()
    {
        if (panelOpciones.sprite == spritePanelBasico) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            panelOpciones.sprite = spritePanelRespuestas;
          //  this.botonOpcion1.GetComponent<Image>().sprite = this.m_spriteOn;

            yield return new WaitForSeconds(3);

            panelOpciones.sprite = spritePanelRtaIncorrecta;

            this.botonOpcion1.gameObject.SetActive(false);
            this.botonOpcion2.gameObject.SetActive(false);
            this.botonOpcion3.gameObject.SetActive(false);

            if (panelOpciones.sprite == spritePanelRtaIncorrecta)
            {
                this.botonReintentar.gameObject.SetActive(true);
                this.botonSalir.gameObject.SetActive(true);

                this.bossAnimator.SetBool("IsBossIdle", true);
                this.bossAnimator.SetBool("IsBossSide", false);
            }
        }
        else
        {
            panelOpciones.sprite = spritePanelBasico; // otherwise change it back to sprite1
        }
    }

    IEnumerator EligeRtaCorrecta()
    {
        if (panelOpciones.sprite == spritePanelBasico) // if the spriteRenderer sprite = sprite1 then change to sprite2
        {
            panelOpciones.sprite = spritePanelRespuestas;

            yield return new WaitForSeconds(3);

            panelOpciones.sprite = spritePanelRtaCorrecta;

            this.botonOpcion1.gameObject.SetActive(false);
            this.botonOpcion2.gameObject.SetActive(false);
            this.botonOpcion3.gameObject.SetActive(false);

            if (panelOpciones.sprite == spritePanelRtaCorrecta)
            {
                this.botonContinuar.gameObject.SetActive(true);

                this.bossAnimator.SetBool("IsBossHappy",true);
                this.amigoAnimator.SetBool("IsAmigoFestejando", true);
            }
        }
        else
        {
            panelOpciones.sprite = spritePanelBasico; // otherwise change it back to sprite1
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bossAnimator.SetBool("IsBossSide", true);
        }
    }
}
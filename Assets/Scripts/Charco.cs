using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    private PlayerMovement m_movimientoJugador;
    private float velocidadNormal = 0f;
    [SerializeField] private float m_velocidadMovimientoReducida;

    private void Start()
    {
        this.m_movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        this.velocidadNormal = this.m_movimientoJugador.runSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.m_movimientoJugador.runSpeed = m_velocidadMovimientoReducida;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.m_movimientoJugador.runSpeed = velocidadNormal;
        }
    }
}

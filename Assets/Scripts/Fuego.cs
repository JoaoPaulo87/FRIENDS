using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    [SerializeField] private AudioSource sonidoGolpe;
    private SistemaVidas player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SistemaVidas>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.sonidoGolpe.Play();
            this.player.PerderVida();
        }
    }
}

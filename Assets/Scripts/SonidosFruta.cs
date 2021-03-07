using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosFruta : MonoBehaviour
{
    private AudioSource au;

    private void Start()
    {
        this.au = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.au.Play();
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }
}

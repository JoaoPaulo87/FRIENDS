using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    public Slider itemsSlider;
    public float aumentoDeAvancePorItem;
    public GameObject bossObject;
    
    void Update()
    {
        if(itemsSlider.value == 1.0)
        {
            bossObject.SetActive(true);
        }
        else
        {
            bossObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Estrella" || collision.gameObject.tag == "Banana")
        {
            itemsSlider.value += aumentoDeAvancePorItem;

            collision.gameObject.GetComponent<AudioSource>().Play();

            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}

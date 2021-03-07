using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItems : MonoBehaviour
{
    public Slider itemsSlider;
    public float aumentoDeAvancePorItem;
    public GameObject bossObject;

    //private GameObject childBossObj;

    // Start is called before the first frame update
    void Start()
    {
        //childBossObj = bossObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(itemsSlider.value == 1.0)
        {
            bossObject.SetActive(true);
            //childBossObj.SetActive(true);
        }
        else
        {
            bossObject.SetActive(false);
            //childBossObj.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Estrella" || collision.gameObject.tag == "Banana")
        {
            itemsSlider.value += aumentoDeAvancePorItem;

            collision.gameObject.GetComponent<AudioSource>().Play();

            //collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}

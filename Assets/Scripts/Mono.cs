using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mono : MonoBehaviour
{
    private void Start()
    {
        gameObject.tag = "Player";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OWCH!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

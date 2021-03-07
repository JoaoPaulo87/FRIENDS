using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;

    public float offset;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 tempX = transform.position;

        tempX.x = playerTransform.position.x;
        tempX.y = playerTransform.position.y + (offset / 3);

        tempX.x += offset;
        //tempX.y += offset; esto queda comentado, sino se va la camara en diagonal superior

        transform.position = tempX;
    }
}

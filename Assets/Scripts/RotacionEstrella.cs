using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEstrella : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * 0.5f);
    }
}

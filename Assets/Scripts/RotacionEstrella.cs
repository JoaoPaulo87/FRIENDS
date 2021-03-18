using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionEstrella : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.forward * 0.5f);
    }
}

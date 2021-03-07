using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    [SerializeField] private Transform targetFollow;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float minLimitX;
    [SerializeField] private float maxLimitX;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetFollow.position.x + offsetX, minLimitX, maxLimitX),
            Mathf.Clamp(transform.position.y, -15.0f, 8.0f),
            transform.position.z);
    }
}
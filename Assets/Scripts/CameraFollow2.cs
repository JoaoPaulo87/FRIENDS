using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    [SerializeField] private Transform targetFollow;
    [SerializeField] private float offsetX = 0f;
    [SerializeField] private float offsetY = 0f;
    [SerializeField] private float minLimitX = 0f;
    [SerializeField] private float maxLimitX = 0f;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetFollow.position.x + offsetX, minLimitX, maxLimitX),
            Mathf.Clamp(transform.position.y, -15.0f, 8.0f),
            transform.position.z);
    }
}
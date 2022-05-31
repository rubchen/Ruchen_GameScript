using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSU : MonoBehaviour
{
    Vector2 senterPos;
    Vector2 rotationPos;
    float startTime;
    [SerializeField] float r;

    void Start()
    {
        senterPos = transform.position;  
    }

    void Update()
    {
        startTime = Time.time + 0.5f;
        float f = 0.5f;
        rotationPos = senterPos;
        rotationPos.x += Mathf.Sin(2 * Mathf.PI * f * startTime)*r;
        rotationPos.y += Mathf.Cos(2 * Mathf.PI * f * startTime)*r;
        transform.position = rotationPos;
    }

}

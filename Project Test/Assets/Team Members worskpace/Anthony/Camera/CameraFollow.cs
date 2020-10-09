using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Header("Camera Variables")]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.one;

    //run right after update
    private void LateUpdate()
    {
      SmoothFollow();
    }

    private void SmoothFollow()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition =
            Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity , smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}



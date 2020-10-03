using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 velocity = Vector3.zero;
    
    [Header("Camera Variables")]
    public float smooth = 0.3f;
    public float height;
    public float zAxis = 10f;


    private void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z - zAxis;
        pos.y = player.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

    }
}

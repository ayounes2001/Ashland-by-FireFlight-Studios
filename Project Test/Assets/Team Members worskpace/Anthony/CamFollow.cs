using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]private bool lockCursor = true;
    public float mouseSensitivity = 10;
    public Transform target;
    public float distanceFromTarget = 2;
    public Vector2 pitchMinMax = new Vector2(-40, 85);
    
    [Header("Smoothing variables and Cam")]
    public float rotationSmoothTime = .12f;
    private Vector3 _rotationSmoothVelocity;
    private Vector3 _currentRotation;
    private Transform _cameraT;

    private float yaw;
    private float pitch;

    private void Start()
    {
        //Checking if the cursor is on the screen
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
       //making sure the we cant go pasted a certain height on our camera.
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
//following the player and setting the distance between our player and camera.
        _currentRotation = Vector3.SmoothDamp(_currentRotation, new Vector3(pitch, yaw), ref _rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = _currentRotation;
        transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
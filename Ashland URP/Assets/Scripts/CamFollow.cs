using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]public bool lockCursor = true;
    public float mouseSensitivity = 3;
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
        // Checking if the cursor is on the screen
#if !UNITY_EDITOR
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
#endif 
        
    }

    private void LateUpdate()
    {
      CamSettings();
    }

    public void CamSettings()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        
        //hey anothony sorry I'm just testing with pitch input off for now back u can change it back if u need to
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity*2;
        //making sure the we cant go pasted a certain height on our camera.
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
   
        //following the player and setting the distance between our player and camera.       
        _currentRotation = Vector3.SmoothDamp(_currentRotation, new Vector3(pitch, yaw), ref _rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = _currentRotation;
        if (!(target is null)) transform.position = target.position - transform.forward * distanceFromTarget;
    }
}

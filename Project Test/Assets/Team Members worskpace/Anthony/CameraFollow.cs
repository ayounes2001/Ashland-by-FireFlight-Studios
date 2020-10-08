using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("Rotate Camera")]
    private CameraMovement controls;
    public float turnSpeed = 4.0f;
    public Transform followTransform;

    private Vector2 rotate;


    private void Awake()
    {
        controls = new CameraMovement();

        controls.Camera.CameraRotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
 
        controls.Camera.CameraRotate.canceled += ctx => rotate = Vector2.zero;
    }

    void Start()
    {
       

    }

    

    private void Update()
    {
       
        followTransform.transform.rotation *= Quaternion.AngleAxis(rotate.x*turnSpeed,Vector3.up);
        followTransform.transform.rotation *= Quaternion.AngleAxis(rotate.y * turnSpeed, Vector3.right);

        var angles = followTransform.transform.localEulerAngles;
        angles.z = 0;
        var angle = followTransform.transform.localEulerAngles.x;

        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }

        followTransform.transform.localEulerAngles = angles;


        transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);

        followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }
    
    void OnEnable()
    {
        controls.Camera.Enable();
    }
 
    void OnDisable()
    {
        controls.Camera.Disable();
    }
}



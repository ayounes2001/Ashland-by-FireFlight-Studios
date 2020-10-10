using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float raycastDistance;
    public PlayerMovement player;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
       
    }
 
    void Update ()
    {
        Jumping();
    }
    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (AmIGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                
            }
            else if(!AmIGrounded())

            {
                player.currentSpeed = player.walkSpeed;
            }
        }

    }

    private bool AmIGrounded()
    {
        Debug.DrawRay(transform.position,Vector3.down* raycastDistance,Color.blue);
        return (Physics.Raycast(transform.position, Vector3.down, raycastDistance));

    }
}


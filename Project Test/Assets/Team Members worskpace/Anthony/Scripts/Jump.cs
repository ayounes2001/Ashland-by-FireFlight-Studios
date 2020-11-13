using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f;
    public PlayerMovement player;
    public bool isGrounded = false;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
       
    }
 
    void FixedUpdate ()
    {
        Jumping();
    }
    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector3(0,jumpForce,0),ForceMode.Impulse);
            isGrounded = false;
        }

    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

}


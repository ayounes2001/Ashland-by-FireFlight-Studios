using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJump : MonoBehaviour
{
    public Rigidbody rb;
    
    public bool isGrounded;
    

    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isGrounded = false;
        }
            
    }

    private void OnCollisionEnter(Collision other)
    {
        
            isGrounded = true;
        
        
    }
}

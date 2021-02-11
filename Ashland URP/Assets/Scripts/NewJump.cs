using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJump : MonoBehaviour
{
    public Rigidbody rb;
    public Animator playerAnimator;
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isGrounded = false;
            //changing to jump animation
            playerAnimator.SetInteger("CurrentAnimation",2);
        }
        //checking if player is falling and chaning animation
        if (rb.velocity.y < -1) { playerAnimator.SetInteger("CurrentAnimation", 4); }            
    }

    private void OnCollisionEnter(Collision other)
    {       
            isGrounded = true;       
    }
}

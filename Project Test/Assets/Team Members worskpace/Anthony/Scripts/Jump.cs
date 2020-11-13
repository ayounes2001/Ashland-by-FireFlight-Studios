using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public Animator JumpPAnimator;
    public Vector3 PlayerVelocity;

    public float jumpForce = 5f;
    public PlayerMovement player;
    public bool isGrounded = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }
    void FixedUpdate ()
    {
        PlayerVelocity = rb.velocity;
        Jumping();
        if (isGrounded == false && JumpPAnimator.GetInteger("CurrentAnimation") != 2)
        {
            JumpPAnimator.SetInteger("CurrentAnimation", 4); //this line is just for if the player is falling
        }
        
    }
    public void Jumping()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            JumpPAnimator.SetInteger("CurrentAnimation", 2); //switching to jumping animation      
            
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded == true) 
        {
            print("jump asshole");          
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
        Landing(JumpPAnimator.GetInteger("CurrentAnimation")); 
    }
    private void Landing(int a)
    { if (a == 4 || a == 2) JumpPAnimator.SetInteger("CurrentAnimation", 0); }
}


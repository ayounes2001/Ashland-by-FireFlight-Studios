using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public Animator JumpPAnimator;  //ANIMATIONS : 0 = idle , 1 = walking , 2 = jumping , 3 = running , 4 = in air 

    public Vector3 PlayerVelocity;

    public float jumpForce = 5f;
    public float JumpSpeed = 5;
    public PlayerMovement player;
    public bool isGrounded = false;
    public bool jumping = false;
    bool space_pressed;
    public GameObject DingoBody;
    private Rigidbody rb;

    int groundLayerMask;


    float spaceDownTime = 0;

    void Start()
    {
        rb = DingoBody.GetComponent<Rigidbody>();
        groundLayerMask = 1 << 8;
        //groundLayerMask = ~ groundLayerMask;
    }
    void Update ()
    {
        PlayerVelocity = rb.velocity;

       if (isGrounded == true)
        { 
            if (Input.GetKey(KeyCode.Space))
            {
                space_pressed = true;               
                Jumping();
                print(spaceDownTime);
            }
            if (Input.GetKeyUp(KeyCode.Space))  { space_pressed = false; }
            if ( spaceDownTime > 30)    { spaceDownTime = 30;}
            if (spaceDownTime < 30) { spaceDownTime = 5;}
        }       
    }
    private void FixedUpdate()
    {

        if (space_pressed == true) { spaceDownTime++; }
        GroundCheck();
    }
    public void Jumping()
    {
         jumping = true;
         JumpPAnimator.SetInteger("CurrentAnimation", 2); //switching to jumping animation      
         print("jump asshole");              
         rb.AddForce(new Vector3(PlayerVelocity.x, jumpForce, PlayerVelocity.z) * (JumpSpeed/2)); 
         StartCoroutine(jumpDelay());
    }

    IEnumerator jumpDelay()
    {
        yield return new WaitForSeconds(spaceDownTime/20);
        JumpPAnimator.SetInteger("CurrentAnimation", 4);
        spaceDownTime = 0;
        jumping = false;
    }

    public float GravitySpeed = 3;
    private float playerHeightOffset = 2;
    bool hasTriggeredIdle = true;
    public void GroundCheck()
    {
        //gravity and ground offset
        
        if(!jumping)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundLayerMask))
            {
                if (Vector3.Distance(this.transform.position, hit.point) > playerHeightOffset) // if we are too far from ground apply gravity
                {
                    transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.down, Time.fixedDeltaTime * GravitySpeed); // move down with gravity 
                    isGrounded = false;
                    hasTriggeredIdle = false;
                }
                else
                {
                    isGrounded = true;
                    if(hasTriggeredIdle == false)
                    {
                        hasTriggeredIdle = true;
                        JumpPAnimator.SetInteger("CurrentAnimation", 0);
                    }
                }
            }
        }

    }    
  
}


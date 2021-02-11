using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public Animator JumpPAnimator;  //ANIMATIONS : 0 = idle , 1 = walking , 2 = jumping , 3 = running , 4 = in air 
    public GameObject DingoBody;
    public Vector3 playerVel;
    private Rigidbody rb;

    public float jumpForce;
    public float jumpSpeed;
    public float jumpHeight;
    float spaceDownTime;
    public float gravitySpeed;
    public float playerHeightOffset;
    private float idealDistance; // the ideal distance for the player to be off the ground. This is half the players scale on the y coordinate 
    int groundLayerMask;

    public bool grounded;
    public bool jumping;
    public bool falling;
    bool space_pressed = false;
      
    void Start()
    {
        rb = DingoBody.GetComponent<Rigidbody>();
        groundLayerMask = 1 << 8;
        idealDistance = transform.localScale.y + playerHeightOffset;
    }
    void Update()
    {
        playerVel = rb.velocity;

        if (grounded == true)
        {
            if (Input.GetKey(KeyCode.Space) && space_pressed == false)
            {
                space_pressed = true;             
                Jumping();
            }
            if (Input.GetKeyUp(KeyCode.Space)) { space_pressed = false; }
            if (spaceDownTime > 5) { spaceDownTime = 5; }; if (spaceDownTime < 0.5f) { spaceDownTime = 0.5f; } //clamps so the player can't just hold down space forever and fly  
        }
        if (falling == true)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.down, Time.fixedDeltaTime * gravitySpeed); // move down with gravity 
        }
        GroundCheck();
    }
    private void FixedUpdate()
    {
        if (space_pressed == true) { spaceDownTime++; }    
    }
    public void Jumping()
    {
        jumping = true;
        JumpPAnimator.SetInteger("CurrentAnimation", 2); //switching to jumping animation     
        rb.AddForce(new Vector3(playerVel.x, playerVel.y + jumpForce, playerVel.z) * (jumpSpeed));
        StartCoroutine(GravityDelay());    
    }
    public void Falling()
    {
        jumping = false;
        falling = true;
        JumpPAnimator.SetInteger("CurrentAnimation", 4);
    }
    IEnumerator GravityDelay()
    {
        yield return new WaitForSeconds(spaceDownTime * jumpHeight);
        Falling();    
       // isGrounded = false;
        spaceDownTime = 0;   
    }
    public void GroundCheck()
    {    
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundLayerMask)) //shooting a raycast down from the player
        {
            //checking if the distance between the player and hit point of raycast is better than ideal distance between player and ground
            if (Vector3.Distance(this.transform.position, hit.point) > idealDistance) 
            {
                grounded = false;
                Debug.DrawRay(transform.position, Vector3.down, Color.green, groundLayerMask);
            }
            else //if the player is the right distance they have either just landed or are already on the ground
            {
                falling = false;
                if (grounded == false) grounded = true; JumpPAnimator.SetInteger("CurrentAnimation", 0); //we change animation when we land first time but not again
                Debug.DrawRay(transform.position, Vector3.down, Color.red, groundLayerMask);              
            }
        }    
    }    
  
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // public NewJump playerjump;
    [Header("Player Animation State")]
    public Animator MovementPAnimator;      //ANIMATIONS : 0 = idle , 1 = walking , 2 = jumping , 3 = running , 4 = in air 


    [Header("Player Speeds")]
    public int walkSpeed;
    public int runSpeed;
    public float currentSpeed;
    public float stamina = 5;
    public float maxStamina = 5;
    
    [Header("Player Movement Smoothing")]
    [SerializeField] private float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    private float speedSmoothVelocity;

    [Header ("UI and Camera")]
    public Slider slider;
    public Transform cameraT;

    private void Start()
    {
        cameraT = Camera.main.transform;
        stamina = maxStamina;
        
        
    }

    private void FixedUpdate()
    {
        Movement();
     
        //***** UI CODE *****
        slider.value = stamina;
        slider.maxValue = maxStamina;
        
    }

    private void Movement()
    {
        //using the old Unity Input System
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDirection = input.normalized;

        //Basing our Input on the direction of the camera and smoothing it out
        if (inputDirection != Vector2.zero)
        {
           // print("moving");
            float targetRotation =
                (Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y);
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,
                ref turnSmoothVelocity, turnSmoothTime);
            if (gameObject.GetComponent<NewJump>().isGrounded && MovementPAnimator.GetInteger("CurrentAnimation") != 2) MovementPAnimator.SetInteger("CurrentAnimation", 1);  //switching to walking animation     
        }
        else { if (gameObject.GetComponent<NewJump>().isGrounded && MovementPAnimator.GetInteger("CurrentAnimation") != 2) { MovementPAnimator.SetInteger("CurrentAnimation", 0); } }//switching to idle animation


        //Changing inbetween normal speed and runningSpeed and actually moving the player
        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((!running) ? walkSpeed : runSpeed) * inputDirection.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        Rigidbody rb = GetComponent<Rigidbody>();

        if (gameObject.GetComponent<NewJump>().isGrounded == true)
        {
            rb.velocity = transform.forward * (currentSpeed * Time.deltaTime);
        }
       
        
        // transform.Translate((transform.forward * (currentSpeed * Time.deltaTime)), Space.World);
     
        
        // ***** STAMINA CODE ********
        if (running )
        {
            stamina -= Time.deltaTime;
            //Debug.Log("Im losing Stam!");
            if (stamina <= 0)
            {
                stamina = 0;
                running = false;
                runSpeed = walkSpeed;
               // Debug.Log("cant run anymore");

                if (gameObject.GetComponent<NewJump>().isGrounded != false && MovementPAnimator.GetInteger("CurrentAnimation") != 2) MovementPAnimator.SetInteger("CurrentAnimation", 1);  //switching to walking animation 
            }
           else { MovementPAnimator.SetInteger("CurrentAnimation", 3); } //switching to running animation
        }
        else if(stamina < maxStamina)
        {
            stamina += Time.deltaTime;
          //  Debug.Log("Regen Stam");
           // runSpeed = 500;
            // currentSpeed = 15f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    public void Death(HealthComponent health)
    {
        Destroy(gameObject);
    }
}

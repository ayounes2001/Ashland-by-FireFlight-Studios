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
    [Header("Player Speeds")]
    public int walkSpeed = 2;
    public int runSpeed = 6;
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

    private void Update()
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
            float targetRotation =
                (Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y);
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,
                ref turnSmoothVelocity, turnSmoothTime);
        }


        //Changing inbetween normal speed and runningSpeed and actually moving the player
        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((!running) ? walkSpeed : runSpeed) * inputDirection.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate((transform.forward * (currentSpeed * Time.deltaTime)), Space.World);
     
        
        // ***** STAMINA CODE ********
        if (running)
        {
            stamina -= Time.deltaTime;
            Debug.Log("Im losing Stam!");
            if (stamina <= 0)
            {
                stamina = 0;
                running = false;
                runSpeed = walkSpeed;
                Debug.Log("cant run anymore");
            }
        }
        else if(stamina < maxStamina)
        {
            stamina += Time.deltaTime;
            Debug.Log("Regen Stam");
            runSpeed = 15;
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

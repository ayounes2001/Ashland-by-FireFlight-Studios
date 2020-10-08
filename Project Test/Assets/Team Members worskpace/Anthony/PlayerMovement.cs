using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;
    public float movementSpeed;
    private Vector2 movementinput;
    private Vector3 moveVector;
    private Vector3 inputDirection;

    private Quaternion currentRotation;
    
    [Header("Jump Variables")]
    public float jumpForce;
    public float raycastDistance;
    private void OnEnable()
    {
        controls.GamePlayer.Enable();
    }

    private void OnDisable()
    {
     controls.GamePlayer.Disable();   
    }

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
    }


    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
    //QUICK SHIT HACK
    var movementInput = controls.GamePlayer.Movement.ReadValue<Vector2>();
    var movement = new Vector3
    {
        x = movementInput.x,
        z = movementInput.y
    }.normalized;
    
    transform.Translate(movement * (movementSpeed * Time.deltaTime),Space.World);
    transform.rotation = Quaternion.LookRotation(movement);
    }
    
    public void Jump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position,Vector3.down * raycastDistance,Color.blue);
        return Physics.Raycast(transform.position,Vector3.down,raycastDistance);
    }
}

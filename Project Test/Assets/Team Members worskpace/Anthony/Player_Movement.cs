using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AnthonyY
{
    public class Player_Movement : MonoBehaviour
    {
        private PlayerControls controls;
        
        [Header("Movement Variables")]
        private Vector2 move;
        public float moveSpeed = 5;
        
        [Header("Jump Variables")]
        public float jumpForce;
        public float raycastDistance;
        
        
        private void Awake()
        {
            controls = new PlayerControls();
            //Take the control performed and do the movement
            controls.PlayerMovement.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.PlayerMovement.Movement.canceled += ctx => move = Vector2.zero;
            controls.PlayerMovement.Jump.performed += Jump;
            

        }

        private void Update()
        {
            Movement();
        }

        void Movement()
        {
            Vector3 m = new Vector3(move.x,0,move.y) * Time.deltaTime;
            transform.Translate(m * moveSpeed, Space.World);

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

        private void OnEnable()
        {
            controls.PlayerMovement.Enable();
        }
        private void OnDisable()
        {
            controls.PlayerMovement.Disable();
        }
    }

}
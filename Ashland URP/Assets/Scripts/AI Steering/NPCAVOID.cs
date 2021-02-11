using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

namespace AnthonyY
{
    public class NPCAVOID : MonoBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody rb;
        public float speed;

        public int damageAmount = 20;
		
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
            rb.AddRelativeForce(0, 0, speed);
            
        }
        //TODO
        //HealthBased code in here
        private void OnCollisionEnter(Collision other)
        {
            // ReSharper disable once Unity.NoNullPropagation
            other.gameObject?.GetComponent<PlayerMovement>()?.GetComponent<HealthComponent>()?.TakeHp(damageAmount);
        }

        void Death()
        {
            gameObject.GetComponent<HealthComponent>()?.Death();
        }
    }
}
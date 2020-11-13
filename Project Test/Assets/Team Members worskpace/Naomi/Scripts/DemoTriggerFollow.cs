using System;
using System.Collections;
using System.Collections.Generic;
using Niall;
using UnityEngine;

namespace AnthonyY
{
    public class DemoTriggerFollow : MonoBehaviour
    {
        public TurnTowardsBehaviour AIscript;
        public NPCAVOID _avoidScript;
        public AvoidBehaviour avoidBehaviourScript;
        private void OnTriggerEnter(Collider other)
        {
         
                print("hi");
                AIscript = GetComponent<TurnTowardsBehaviour>();
                AIscript.enabled = true;
                _avoidScript = GetComponent<NPCAVOID>();
                _avoidScript.enabled = true;

                avoidBehaviourScript = GetComponent<AvoidBehaviour>();
                avoidBehaviourScript.enabled = true;

        }
     
    }
}


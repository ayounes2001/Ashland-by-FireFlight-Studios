using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;

public class AIFollowStop : MonoBehaviour
{
    public float npcNewSpeed = 15f;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            other.gameObject.GetComponent<NPCAVOID>().speed = 0;
            other.gameObject.GetComponent<Animator>().SetInteger("CurrentAnimation", 0); //changing animation to idle in AIs animator controller 

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject != null)
        {
            other.gameObject.GetComponent<NPCAVOID>().speed = npcNewSpeed;
            other.gameObject.GetComponent<Animator>().SetInteger("CurrentAnimation", 1); //changing animation to Run in AIs animator controller 
           // print("don't leave me");
        }
      
    }
}

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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject != null)
        {
            other.gameObject.GetComponent<NPCAVOID>().speed = npcNewSpeed;
        }
      
    }
}

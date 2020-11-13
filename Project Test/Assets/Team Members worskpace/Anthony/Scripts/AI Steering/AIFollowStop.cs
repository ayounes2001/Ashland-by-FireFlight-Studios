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
        other.gameObject.GetComponent<NPCAVOID>().speed = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<NPCAVOID>().speed = npcNewSpeed;
    }
}

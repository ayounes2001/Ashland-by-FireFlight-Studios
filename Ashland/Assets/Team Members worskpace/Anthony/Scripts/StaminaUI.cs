using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    private PlayerMovement player;

    public Slider slider;
    
    // Start is called before the first frame update
    void Update()
    {
        slider.value = player.stamina;
        slider.maxValue = player.maxStamina;
    }
    
    
}

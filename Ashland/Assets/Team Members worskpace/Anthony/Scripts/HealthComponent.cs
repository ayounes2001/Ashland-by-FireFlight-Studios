using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth = 100;

    public Slider slider;

    public UnityEvent<HealthComponent> deathEvent;

    //sorry anythony you can change this whenever its just for the demo
    public GameObject DeadText;

    private void Update()
    {
        if (!(slider is null))
        {
            slider.value = currentHealth;
            slider.maxValue = MaxHealth;
        }
    }

    public void AddHp(int amount)
    {
        currentHealth += amount;
    }

    public void TakeHp(int amount)
    {
        currentHealth -= amount;
        if( currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if(deathEvent!=null)
        {
            deathEvent.Invoke(this);
            Destroy(gameObject);
            DeadText.SetActive(true);
        }           
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
   [SerializeField]
   private int damageAmount = 1;
   private void OnTriggerStay(Collider other)
   {
      // ReSharper disable once Unity.NoNullPropagation
      other.gameObject?.GetComponent<PlayerMovement>()?.GetComponent<HealthComponent>()?.TakeHp(damageAmount);
   }
   void Death()
   {
      gameObject.GetComponent<HealthComponent>()?.Death();
   }
}

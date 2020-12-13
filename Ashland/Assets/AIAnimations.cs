using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimations : MonoBehaviour
{
    public Animator aniMator;
    Rigidbody AIrb;
    public float IdleDistance;
    Vector3 dIstance;
    private void Start()
    {
        AIrb = GetComponent<Rigidbody>();
       dIstance = new Vector3(IdleDistance, 0, IdleDistance);
    }
   private void FixedUpdate()
   {
        if (AIrb.velocity.x <= IdleDistance && AIrb.velocity.z <= IdleDistance) { aniMator.SetInteger("CurrentAnimation", 0); }
        else { aniMator.SetInteger("CurrentAnimation", 1); }
   }
   // private void OnTriggerEnter(Collider other)
   // {
   //     aniMator.SetInteger("CurrentAnimation", 0);
   // }
   // private void OnTriggerExit(Collider other)
   // {
   //     aniMator.SetInteger("CurrentAnimation", 1);
   // }
}

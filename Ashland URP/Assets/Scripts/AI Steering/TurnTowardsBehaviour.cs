using System;
using System.Collections;
using System.Collections.Generic;
using Niall;
using UnityEngine;

namespace AnthonyY 
{
    public class TurnTowardsBehaviour : SteeringBehaviourBase
    {

        public Transform FollowPos = null;
        public float force = 0.1f;
        private LineOfSight lineOfSight;
        public bool playerfollow;
        
        public void Update()
        {

            if (/*lineOfSight.Los() &&*/ FollowPos != null)
            {
                Vector3 targetDelta = FollowPos.position - transform.position;

                float angleDiff = Vector3.Angle(transform.forward, targetDelta);

                Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

                GetComponent<Rigidbody>().AddTorque(cross * (angleDiff * (force * Time.deltaTime)));
            }
        }
    }
}

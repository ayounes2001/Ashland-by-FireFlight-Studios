using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public float speed = 0.001f;

    public float rotationSpeed = 4f;

    private Vector3 averageHeading;

    private Vector3 averagePositon;

    public float neighBourDistance = 3.0f;

    public float flockTiming = 5 ;

    private bool turning = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
      FlockRules();
    }
    private void FlockRules()
    {
        if (Vector3.Distance(transform.position, GlobalFlock.goalPos) >= GlobalFlock.tankSize)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            Vector3 direction = GlobalFlock.goalPos - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(0.5f, 1);
        }
        else
        {
            if (Random.Range(0, flockTiming) < 1)
            {
                ApplyRules();
            }
        }
        transform.Translate(0,0,Time.deltaTime * speed);
    }

    private void ApplyRules()
    {
        //References to surrounding birds
        GameObject[] gos;
        gos = GlobalFlock.allBirds;
       
        //Some AI Behaviours
        Vector3 vCentre = GlobalFlock.goalPos;
        Vector3 vAvoid = GlobalFlock.goalPos;
        float groupSpeed = 0.1f;

        Vector3 goalPos = GlobalFlock.goalPos;

        float dist;

        int groupSize =0;
        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                //check whether we are in a certain distance
                if (dist <= neighBourDistance)
                {
                    vCentre += go.transform.position;
                    groupSize++;
                }

                if (dist < 1.0f)
                {
                    vAvoid = vAvoid + (this.transform.position - go.transform.position);
                }
//Grabbing the other flocks speed to see if they should join
                Flock anotherFlock = go.GetComponent<Flock>();
                groupSpeed = groupSpeed + anotherFlock.speed;
            }
//Average speed for the entire group
            if (groupSize > 0)
            {
                //grabbing the average the centre and avoid bird
                vCentre = vCentre / groupSize + (goalPos = this.transform.position);
                speed = groupSpeed / groupSize;

                Vector3 direction = (vCentre + vAvoid) - transform.position;
                if (direction != GlobalFlock.goalPos)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed * Time.deltaTime);
                }
                

            }
        }
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoketrigger : MonoBehaviour
{
  
    public GameObject Smoke;
  
    public bool smoke =true;
  
    // Update is called once per frame
  
    private void FixedUpdate()
  
    {
  
        if (Input.GetKeyDown(KeyCode.F) && smoke == false) { smoke = true; print("turn on smoke"); Smoke.SetActive(true); }
  
        if (Input.GetKeyDown(KeyCode.G) && smoke == true) { smoke = false; print("turn off smoke"); Smoke.SetActive(false); }
  
    }
}

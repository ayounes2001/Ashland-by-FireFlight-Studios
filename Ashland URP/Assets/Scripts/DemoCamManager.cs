using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCamManager : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject FireCam;

    void LateUpdate()
    {
        // if (Input.GetAxis("Vertical") < 0) { MainCam.SetActive(false); FireCam.SetActive(true); }
        // else if (Input.GetAxis("Vertical") > 0) { FireCam.SetActive(false); MainCam.SetActive(true); }


        if (Input.GetKeyDown(KeyCode.E))
        {
            MainCam.SetActive(false);
            FireCam.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            MainCam.SetActive(true);
            FireCam.SetActive(false);
        }

    }  
}

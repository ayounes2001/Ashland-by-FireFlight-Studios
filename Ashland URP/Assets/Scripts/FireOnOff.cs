using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnOff : MonoBehaviour
{
    public GameObject Fire;
    public GameObject AudioManager;
    public bool AudioOn = false;
    public bool FireOn = false;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && FireOn == false) { FireOn = true; AudioOn = false; print("turn on fire"); Fire.SetActive(true); AudioManager.SetActive(false); }

        if (Input.GetKeyDown(KeyCode.R) && (FireOn == true || AudioOn== false)) { FireOn = false; AudioOn = true; print("turn off fire"); Fire.SetActive(false); AudioManager.SetActive(true); }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersOnOff : MonoBehaviour
{
    public GameObject CharacterModels;
    public bool CharactersOn = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && CharactersOn == false) { CharactersOn = true; print("turn on Characters"); CharacterModels.SetActive(true); }

        if (Input.GetKeyDown(KeyCode.X) && CharactersOn == true) { CharactersOn = false; print("turn off Characters"); CharacterModels.SetActive(false); }
    }
}

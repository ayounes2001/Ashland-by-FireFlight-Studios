using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersOnOff : MonoBehaviour
{
    public GameObject CharacterModels;
    public GameObject SamundrasModels;
    public bool SamundrasModelsOn = false;
    public bool CharactersOn = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && CharactersOn == false) { CharactersOn = true; SamundrasModelsOn = false; print("turn on Characters"); CharacterModels.SetActive(true); SamundrasModels.SetActive(false); }

        if (Input.GetKeyDown(KeyCode.X) && (CharactersOn == true||SamundrasModelsOn == false)) { CharactersOn = false; SamundrasModelsOn = true; print("turn off Characters"); CharacterModels.SetActive(false); SamundrasModels.SetActive(true); }
    }
}

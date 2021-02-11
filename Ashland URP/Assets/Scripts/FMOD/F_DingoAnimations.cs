using FMODUnity;
using UnityEngine;

public class F_DingoAnimations : MonoBehaviour
{
    public void DingoStep()
    {
        RuntimeManager.PlayOneShot("event:/Dingo/Footsteps");
    }
    public void DingoStepRun()
    {
        
    }
}
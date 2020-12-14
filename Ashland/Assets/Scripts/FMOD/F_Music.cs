using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_Music : MonoBehaviour
{
    private EventInstance music;
    void Start()
    {
        music = RuntimeManager.CreateInstance("event:/Music/Music");
        music.start();
        music.release();
    }
}

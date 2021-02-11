using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class RandomUI : MonoBehaviour
{
    public PlayerMovement player;

    public Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Current Speed:" + player.currentSpeed.ToString();
    }
}

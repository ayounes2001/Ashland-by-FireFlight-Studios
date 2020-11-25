using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    public GameObject birdPrefab;
    public GameObject goalPrefab;
    public int randomMovement = 1000;

    public static int tankSize = 5;
    

    public static int numBirds = 10;

    public static GameObject[] allBirds = new GameObject[numBirds];

    public static Vector3 goalPos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBirds; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize));
            allBirds[i] = (GameObject) Instantiate(birdPrefab, pos, Quaternion.identity);
        }   
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

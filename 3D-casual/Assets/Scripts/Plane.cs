using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject controller;
    
  
    // Start is called before the first frame update
    void Start()
    {
        

    }


    private void OnCollisionEnter(Collision collision)
    {
        controller.GetComponent<GameController>().canSpawnBall = true;
    }
}

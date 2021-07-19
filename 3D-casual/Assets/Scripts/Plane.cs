using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject controller;
    
  
  

    private void OnCollisionEnter(Collision collision)
    {
        controller.GetComponent<GameController>().canSpawnBall = true;
    }
}

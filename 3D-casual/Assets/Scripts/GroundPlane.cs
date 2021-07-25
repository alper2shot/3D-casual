using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlane : MonoBehaviour
{
    public int needCount;
    public int counter = 0;
    public GameObject controller;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Block"))
        counter++;

        collider.tag = "Counted";
        

    }

    void Update()
    {
        if(needCount == counter)
        {
            controller.GetComponent<GameController>().groundPlane = true;
        }
    }
}

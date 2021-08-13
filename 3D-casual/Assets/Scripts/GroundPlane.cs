using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlane : MonoBehaviour
{
    public int needCount;
    public int counter = 0;
    public GameObject controller;

    void Update()
    {
        if(needCount == counter)
        {
            controller.GetComponent<GameController>().groundPlane = true;
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Block") && !collider.CompareTag("Counted"))
        {
            gameObject.transform.root.GetComponent<GroundPlane>().counter++;
            AudioManagerScript.PlaySound(AudioManagerScript.Sound.groundPlane);
            collider.tag = "Counted";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlane : MonoBehaviour
{
    public int needCount;
    public int counter = 0;
    public bool pass = false;

    private void OnTriggerEnter(Collider collider)
    {
        counter++;
    }

    // Update is called once per frame
    void Update()
    {
        if(needCount == counter)
        {
            pass = true;
        }
    }
}

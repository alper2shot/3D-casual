using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlanePart : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Block") && !collider.CompareTag("Counted"))
        {
            GameObject.FindGameObjectWithTag("GroundPlane").GetComponent<GroundPlane>().counter++;
            AudioManagerScript.PlaySound(AudioManagerScript.Sound.groundPlane);
            collider.tag = "Counted";
        }
    }
}

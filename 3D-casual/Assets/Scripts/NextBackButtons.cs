using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBackButtons : MonoBehaviour
{
    public GameObject first;
    public GameObject second;

    public void Pass()
    {
        AudioManagerScript.PlaySound(AudioManagerScript.Sound.click);
        second.SetActive(true);
        first.SetActive(false);
        
    }
}

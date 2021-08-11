using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumer : MonoBehaviour
{
    public float Volume;
    //public GameObject audioPlayer;
    private void Start()
    {
        PlaySound.ChangeVolume(Volume);
    }

}

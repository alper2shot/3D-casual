using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySound : MonoBehaviour
{
    static PlaySound instance;
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
    }
   

    public void StopSound()
    {
        audioSource.Stop();
    }

    public void ContinueSound()
    {
        audioSource.Play();
    }
}

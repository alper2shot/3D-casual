using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsVolume : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;
    private GameObject player;
    private AudioSource audioSource;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlaySound");
        audioSource = player.GetComponent<AudioSource>() ;

        if (PlayerPrefs.HasKey("masterVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
            slider.value = PlayerPrefs.GetFloat("masterVolume");
        }
        else
            PlayerPrefs.SetFloat("masterVolume", 1f);

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
            slider2.value = PlayerPrefs.GetFloat("musicVolume");
        }
        else
            PlayerPrefs.SetFloat("musicVolume", 0.1f);
    }

 
    // Update is called once per frame
    void Update()
    {
        
        AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
        slider.value = PlayerPrefs.GetFloat("masterVolume");

        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        slider2.value = PlayerPrefs.GetFloat("musicVolume");


    }

    public void Save()
    {
        PlayerPrefs.SetFloat("masterVolume", slider.value);
    }
    public void SaveMusic()
    {
        PlayerPrefs.SetFloat("musicVolume", slider2.value);
    }
}

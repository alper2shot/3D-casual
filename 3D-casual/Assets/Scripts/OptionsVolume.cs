using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsVolume : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    { 
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
            slider.value = PlayerPrefs.GetFloat("masterVolume");
        }
        else
            PlayerPrefs.SetFloat("masterVolume", 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
         AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
         slider.value = PlayerPrefs.GetFloat("masterVolume");
       
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("masterVolume", slider.value);
    }
}

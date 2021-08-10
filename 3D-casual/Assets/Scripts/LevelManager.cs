using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelStars = new GameObject[24];

    static LevelManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
    }

    void Start()
    {
        for(int a = 24; a>0; a--)
        {
            if(PlayerPrefs.HasKey(a.ToString()))
            {
                levelStars[a - 1].GetComponent<LevelScore>().starCount = PlayerPrefs.GetInt(a.ToString());

            }

        }
        
    }
}

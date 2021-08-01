using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelStars = new GameObject[20];
    public int levelNumber;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}

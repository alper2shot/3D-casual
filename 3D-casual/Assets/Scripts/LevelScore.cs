using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    public int starCount;
    public bool isLevelActive;
    public GameObject activeImage;
    public GameObject passiveImage;
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;

    private void Start()
    {

        if (isLevelActive) {

            activeImage.SetActive(true);
            passiveImage.SetActive(false);
            
            if (starCount == 0)
            {
                oneStar.SetActive(false);
                twoStar.SetActive(false);
                threeStar.SetActive(false);
            }
            else if(starCount == 1)
            {
                oneStar.SetActive(true);
                twoStar.SetActive(false); 
                threeStar.SetActive(false);
            }

            else if(starCount == 2)
            {
                twoStar.SetActive(true);
                oneStar.SetActive(false);
                threeStar.SetActive(false);
            }

            else if (starCount == 3)
            {
                twoStar.SetActive(false);
                oneStar.SetActive(false);
                threeStar.SetActive(true);
            }
        }
    }
}

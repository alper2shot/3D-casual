using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public int starCount;
    public int sceneNo;
    public bool isLevelActive;
    public GameObject activeImage;
    public GameObject passiveImage;
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;
    public Button levelButton;

    private void Start()
    {
        levelButton.interactable = isLevelActive;
    }
    
    private void Update()
    {

        if (isLevelActive) {

            levelButton.interactable = true;

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

    public void LoadScene()
    {
        //add animation 
        SceneManager.LoadScene(sceneNo +2);
        transform.root.gameObject.GetComponent<Canvas>().GetComponent<Canvas>().enabled = false;
    }

}

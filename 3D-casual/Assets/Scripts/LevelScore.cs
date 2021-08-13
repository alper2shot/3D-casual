using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    
    public int starCount;
    public int sceneNo;
    public static int openTilThis;
    public bool isLevelActive;
    public GameObject activeImage;
    public GameObject passiveImage;
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;
    public Button levelButton;
    

    private void Start()
    {

        openTilThis = PlayerPrefs.GetInt("openTilThis");
        //levelButton.interactable = isLevelActive;
    }
    
    private void Update()
    {
        
        if (sceneNo <= openTilThis)
        {
            isLevelActive = true;
        }

        if (isLevelActive) {

            if(levelButton != null)
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
        StartCoroutine(SceneLoader());
    }

    IEnumerator SceneLoader()
    {
        AudioManagerScript.PlaySound(AudioManagerScript.Sound.click);
        transform.root.gameObject.GetComponent<DontDestroy>().animatorTrigger = true;
        yield return new WaitForSeconds(1);
        transform.root.gameObject.GetComponent<Canvas>().GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene(sceneNo + 1);
        
    }


    
}

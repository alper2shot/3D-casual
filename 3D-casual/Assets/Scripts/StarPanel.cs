using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarPanel : MonoBehaviour
{
    public GameObject winStats;
    public GameObject loseStats;
    public GameObject pauseButton;
    public GameObject gameController;
    public GameObject oneStar;
    public GameObject twoStar;
    public GameObject threeStar;
    public Animator animator;
    public Animator animatorLose;

    private bool once = true;

    public void ContinueButton()
    {
       
        Time.timeScale = 1f;
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelMenuButton()
    {
        
        Time.timeScale = 1f;
  
        SceneManager.LoadScene(1);
    }

    public void RestartButton()
    {
       
        Time.timeScale = 1f;
 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (gameController.GetComponent<GameController>().starCount == 0 && once)
        {
            AudioManagerScript.PlaySound(AudioManagerScript.Sound.loseSound);
            loseStats.SetActive(true);
            //animatorLose.SetTrigger("start");
            pauseButton.SetActive(false);
            once = false;
        }
        else if (gameController.GetComponent<GameController>().starCount == 1 && once)
        {
            AudioManagerScript.PlaySound(AudioManagerScript.Sound.winSound);
            winStats.SetActive(true);
            //animator.SetTrigger("start");
            oneStar.SetActive(true);
            pauseButton.SetActive(false);
            once = false;
        }
        else if (gameController.GetComponent<GameController>().starCount == 2 && once)
        {
            AudioManagerScript.PlaySound(AudioManagerScript.Sound.winSound);
            winStats.SetActive(true);
            //animator.SetTrigger("start");
            twoStar.SetActive(true);
            pauseButton.SetActive(false);
            once = false;
        }
        else if (gameController.GetComponent<GameController>().starCount == 3 && once)
        {
            AudioManagerScript.PlaySound(AudioManagerScript.Sound.winSound);
            winStats.SetActive(true);
            //animator.SetTrigger("start");
            threeStar.SetActive(true);
            pauseButton.SetActive(false);
            once = false;
        }
    }
}
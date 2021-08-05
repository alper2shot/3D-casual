using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool playedOnce;
    public Animator animator;

    public void Play()
    {
        playedOnce = GameObject.FindGameObjectWithTag("Tracker").GetComponent<PlayButtonTracker>().playedOnce;

        if (!playedOnce)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameObject.FindGameObjectWithTag("Tracker").GetComponent<PlayButtonTracker>().playedOnce = true;
        }
        
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator PlayTransition()
    {
        //animator.SetTrigger("");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

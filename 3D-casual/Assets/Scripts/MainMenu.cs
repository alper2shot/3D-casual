using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool playedOnce;
    public Animator animator;

    IEnumerator Transition()
    {
        animator.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Play()
    {
        playedOnce = GameObject.FindGameObjectWithTag("Tracker").GetComponent<PlayButtonTracker>().playedOnce;

        if (!playedOnce)
        {
            StartCoroutine(Transition());
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

    
}

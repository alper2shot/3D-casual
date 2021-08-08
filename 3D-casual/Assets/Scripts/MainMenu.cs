using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public Image panel;

    IEnumerator Transition()
    {
        panel.raycastTarget = true;
        animator.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Play()
    {

       StartCoroutine(Transition());

    }

    public void Quit()
    {
        Application.Quit();
    }

    
}

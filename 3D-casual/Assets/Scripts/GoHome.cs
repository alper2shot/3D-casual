using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour
{
    public GameObject canvasStay;
    
    public void LoadHomeScene()
    {
        StartCoroutine(Loader());
    }

    IEnumerator Loader()
    {
        AudioManagerScript.PlaySound(AudioManagerScript.Sound.click);
        canvasStay.GetComponent<DontDestroy>().animatorTrigger = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}

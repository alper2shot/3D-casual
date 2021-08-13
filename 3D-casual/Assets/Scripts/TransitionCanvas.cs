using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionCanvas : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;

    private void Start()
    {
        PlaySound.ChangeVolume(0f);
    }

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void LevelMenuButton()
    {
        
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void NextLevelButton()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}

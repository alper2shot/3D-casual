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
        PlaySound.ChangeVolume(0.2f);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

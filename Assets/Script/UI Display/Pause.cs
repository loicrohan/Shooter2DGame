using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    public void ClickOnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButtonClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void HelpButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Help(Pause)");
    }
}
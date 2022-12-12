using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    /*public Button StartButton;
    public Button propertiesButton;
    public Button helpButton;
    public Button closeButton;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitButtonClicked()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void HelpButtonClicked()
    {
        SceneManager.LoadScene("Help");
    }
}
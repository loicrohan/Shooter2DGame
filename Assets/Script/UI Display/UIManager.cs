using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Text _resultText;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score:" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int currentLives)
    {
        Debug.Log(currentLives);
        _livesImage.sprite = _liveSprites[currentLives];
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score:" + playerScore.ToString();
        _resultText.text = playerScore.ToString();
    }

    public void CloseButtonClicked(string Menu)
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReplayButtonClicked(string Level1)
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }
}

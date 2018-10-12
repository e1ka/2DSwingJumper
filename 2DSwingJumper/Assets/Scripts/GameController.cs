using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText, highScoreText, newHighScoreText;
    public GameObject gameOverObj;
    
    private int score, highScore;

    private bool newHighScore = false;

	void Start ()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        DisplayHighScore();
        score = 0;
        UpdateScore();
    }

    private void DisplayHighScore()
    {
        highScoreText.text = highScore.ToString();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", score);
            DisplayHighScore();
            if (!newHighScore)
                newHighScore = true;
        }
            
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void GameOver()
    {
        gameOverObj.SetActive(true);
        if (newHighScore)
        {
            newHighScoreText.text = "NEW HIGHSCORE!";
        }
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

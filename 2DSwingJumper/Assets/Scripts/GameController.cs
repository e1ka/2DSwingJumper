using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText, highScoreText, gameOver;

    private bool gameover, restart;
    private int score, highScore;

	void Start ()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        DisplayHighScore();
        gameover = false;
        restart = false;
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
        }
            
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void GameOver()
    {
        gameOver.text = "GAME OVER";
        gameover = true;
    }
}

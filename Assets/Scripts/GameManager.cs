using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public int score;

    public int bestScore;

    public Text ScoreText;

    public Text BestScoreText;

    private void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = bestScore.ToString();

    }
    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            BestScoreText.text = score.ToString();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}

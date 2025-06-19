using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int bestScore;

    public Text ScoreText;
    public Text BestScoreText;

    private DatabaseManager dbManager;

    private void Start()
    {
        dbManager = FindObjectOfType<DatabaseManager>();

        score = 0;
        ScoreText.text = score.ToString();

        bestScore = dbManager.GetBestScore();
        BestScoreText.text = bestScore.ToString();
    }

    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();

        if (score > bestScore)
        {
            bestScore = score;
            BestScoreText.text = bestScore.ToString();
        }
    }

    public void RestartGame()
    {
        dbManager.InsertScore(score, bestScore);
        SceneManager.LoadScene("PlayScene");
    }
}

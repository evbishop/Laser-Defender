using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreHandler scoreHandler;

    void Start()
    {
        scoreHandler = FindObjectOfType<ScoreHandler>();
        scoreHandler.OnScoreUpdated += UpdateScore;
        UpdateScore(scoreHandler.Score);
    }

    void OnDestroy()
    {
        scoreHandler.OnScoreUpdated -= UpdateScore;
    }

    void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}

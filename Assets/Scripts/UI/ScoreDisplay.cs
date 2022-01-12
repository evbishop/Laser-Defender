using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreHander scoreHandler;

    void Start()
    {
        scoreHandler.OnScoreUpdated += UpdateScore;
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

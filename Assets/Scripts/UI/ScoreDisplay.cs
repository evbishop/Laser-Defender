using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    ScoreHander scoreHandler;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreHandler = FindObjectOfType<ScoreHander>();
    }

    void Update()
    {
        scoreText.text = scoreHandler.Score.ToString();
    }
}

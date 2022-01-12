using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHander : Singleton
{
    public int Score { get; set; }

    void Start()
    {
        LevelLoader.OnResetScore += ResetScore;
    }

    void OnDestroy()
    {
        LevelLoader.OnResetScore -= ResetScore;
    }

    void ResetScore()
    {
        Destroy(gameObject);
    }
}

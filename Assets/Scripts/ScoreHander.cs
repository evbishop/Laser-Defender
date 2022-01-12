using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHander : Singleton
{
    int score;
    public event Action<int> OnScoreUpdated;
    
    void Start()
    {
        LevelLoader.OnResetScore += ResetScore;
        Enemy.OnScoreIncreased += RaiseScore;
    }

    void OnDestroy()
    {
        LevelLoader.OnResetScore -= ResetScore;
        Enemy.OnScoreIncreased -= RaiseScore;
    }

    void ResetScore()
    {
        Destroy(gameObject);
    }

    void RaiseScore(int raise)
    {
        score += raise;
        OnScoreUpdated?.Invoke(score);
    }
}

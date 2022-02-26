using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : Singleton
{
    public event Action<int> OnScoreUpdated;

    int score;
    public int Score 
    { 
        get { return score; }
        private set
        { 
            score = value;
            OnScoreUpdated?.Invoke(score);
        }
    }
    
    void Start()
    {
        LevelLoader.OnResetScore += ResetScore;
        EnemyStatus.OnScoreIncreased += RaiseScore;
    }

    void OnDestroy()
    {
        LevelLoader.OnResetScore -= ResetScore;
        EnemyStatus.OnScoreIncreased -= RaiseScore;
    }

    void ResetScore()
    {
        Destroy(gameObject);
    }

    void RaiseScore(int raise)
    {
        Score += raise;
    }
}

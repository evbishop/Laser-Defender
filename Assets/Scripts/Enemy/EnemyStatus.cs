using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : Status
{
    [SerializeField] int scoreValue = 100;

    public static event Action<int> OnScoreIncreased;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (Health <= 0) Die();
    }

    protected override void Die()
    {
        OnScoreIncreased?.Invoke(scoreValue); 
        base.Die();
    }
}

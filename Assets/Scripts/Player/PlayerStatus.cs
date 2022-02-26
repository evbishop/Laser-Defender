using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status
{
    public event Action<int> OnPlayerHealthUpdated;
    public static event Action OnPlayerDeath;

    public override int Health 
    { 
        get { return health; } 
        protected set
        {
            health = Mathf.Max(0, value);
            OnPlayerHealthUpdated?.Invoke(health);
            if (health == 0) OnPlayerDeath?.Invoke();
        }
    }

    void Start()
    {
        OnPlayerDeath += Die;
    }

    void OnDestroy()
    {
        OnPlayerDeath -= Die;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int Score { get; set; }

    void Awake()
    {
        SetUpSingleton();
    }

    void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}

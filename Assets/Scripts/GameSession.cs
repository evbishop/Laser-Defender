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
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
            Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}

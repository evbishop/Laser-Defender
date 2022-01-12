using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : Singleton
{
    public int Score { get; set; }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHander : Singleton
{
    public int Score { get; set; }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}

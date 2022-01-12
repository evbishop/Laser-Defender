﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    IEnumerator Start()
    {
        do { yield return StartCoroutine(SpawnAllWaves()); }
        while (looping);
    }

    IEnumerator SpawnAllWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++)
        {
            var newEnemy = Instantiate(
                waveConfig.EnemyPrefab,
                waveConfig.Waypoints[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().WaveConfiguration = waveConfig;
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }
}

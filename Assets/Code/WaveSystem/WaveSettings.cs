using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "Game Data/Wave")]
public class WaveSettings : ScriptableObject
{
    [SerializeField] private List<WaveEnemy> waveEnemies;
    public EventRaiser OnWaveStarted;
    public EventRaiser OnWaveEnded;

    private int currentWave = 0;
    public int CurrentWave { get { return currentWave; } }

    private int enemiesSpawned = 0;
    public int EnemiesSpawned { get { return enemiesSpawned; } }

    private int currentPrice = 0;
    public int CurrentPrice { get { return currentPrice; } }
    private List<WaveEnemy> availableEnemies;

    public void Setup(Transform transform)
    {
        foreach (WaveEnemy waveEnemy in waveEnemies)
        {
            waveEnemy.ObjectPool.Initialize(transform);
        }
    }

    public void StartNewWave()
    {
        OnWaveStarted?.RaiseEvent();
        currentWave++;
        currentPrice = (int)Math.Pow(currentWave + 1, 2);
        enemiesSpawned = 0;

        foreach (WaveEnemy waveEnemy in waveEnemies)
        {
            availableEnemies.Add(waveEnemy);
        }
    }

    public void FinishWave()
    {
        OnWaveEnded?.RaiseEvent();
    }

    public void InstantiateEnemy(Vector3 position, Quaternion rotation)
    {
        WaveEnemy enemy = availableEnemies[UnityEngine.Random.Range(0, availableEnemies.Count)];
        enemy.ObjectPool.Instantiate(position, rotation);
        enemiesSpawned++;

        currentPrice -= enemy.Cost;
        if (currentPrice - enemy.Cost < 0)
        {
            availableEnemies.Remove(enemy);
        }
    }
}
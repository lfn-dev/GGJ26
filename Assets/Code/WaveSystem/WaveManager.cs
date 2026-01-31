using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveRunner waveRunner;
    [SerializeField] private WaveSettings wave;

    private int enemiesDefeated = 0;
    private bool waveIsRunning = false;

    private void Awake()
    {
        wave.Setup(transform);
    }

    public void StartNextWave()
    {
        wave.StartNewWave();
        enemiesDefeated = 0;
        waveIsRunning = true;
    }

    public void Update()
    {
        if (!waveIsRunning)
        {
            return;
        }

        waveRunner.Run(wave);
    }

    public void CheckIfWaveEnded()
    {
        enemiesDefeated++;
        if (enemiesDefeated == wave.EnemiesSpawned && wave.CurrentPrice <= 0)
        {
            wave.FinishWave();
            waveIsRunning = false;
        }
    }
}

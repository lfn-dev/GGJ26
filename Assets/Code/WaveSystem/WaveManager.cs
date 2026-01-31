using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WaveSettings wave;

    private int enemiesDefeated = 0;

    private void Awake()
    {
        wave.Setup(transform);
    }

    public void StartNextWave()
    {
        wave.StartNewWave();
    }

    public void CheckIfWaveEnded()
    {
        if (enemiesDefeated == wave.EnemiesSpawned && wave.CurrentPrice <= 0)
        {
            wave.FinishWave();
        }
    }
}

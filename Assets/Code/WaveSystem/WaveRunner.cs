using UnityEngine;

[System.Serializable]
public class WaveRunner
{
    [SerializeField] private float spawnRadius = 25f;
    private float timeSinceLastSpawn = 0f;

    public void Run(WaveSettings waveSettings)
    {
        if (timeSinceLastSpawn > 0f)
        {
            timeSinceLastSpawn -= Time.deltaTime;
            return;
        }

        WaveEnemy enemy = waveSettings.GetEnemyToSpawn();
         
        if (enemy == null)
        {
            return;
        }

        timeSinceLastSpawn = enemy.SpawnCooldown;

        Vector2 spawnPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * spawnRadius;
        enemy.ObjectPool.Instantiate(spawnPosition, Quaternion.identity);
    }
}
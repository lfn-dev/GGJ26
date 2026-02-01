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

        float angle = Random.Range(1f, 360f);

        Vector2 spawnPosition = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad))
        * spawnRadius;
        
        enemy.ObjectPool.Instantiate(spawnPosition, Quaternion.identity);
    }
}
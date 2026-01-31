using UnityEngine;

public class WaveEnemy
{
    [SerializeField] private int cost;
    public int Cost { get { return cost; } }
    [SerializeField] private float spawnCooldown;
    public float SpawnCooldown { get { return spawnCooldown; } }
    [SerializeField] private ObjectPool objectPool;
    public ObjectPool ObjectPool { get { return objectPool; } }
}
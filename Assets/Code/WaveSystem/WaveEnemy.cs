using UnityEngine;

[System.Serializable]
public class WaveEnemy
{
    [SerializeField] private ObjectPool objectPool;
    public ObjectPool ObjectPool { get { return objectPool; } }
    [SerializeField] private int cost;
    public int Cost { get { return cost; } }
    [SerializeField] private float spawnCooldown;
    public float SpawnCooldown { get { return spawnCooldown; } }
}
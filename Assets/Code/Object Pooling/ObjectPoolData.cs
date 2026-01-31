using UnityEngine;

[System.Serializable]
public class ObjectPoolData
{
    [SerializeField] private string poolKey;
    public string PoolKey { get { return poolKey; } }
    [SerializeField] private ObjectPool objectPool;
    public ObjectPool ObjectPool { get { return objectPool; } }
    
    [SerializeField] private Transform instancesParent;

    public void Initialize()
    {
        ObjectPool.Initialize(instancesParent);
    }
}
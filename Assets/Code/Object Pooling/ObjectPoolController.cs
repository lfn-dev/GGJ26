using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolData> objectPools;
    [SerializeField] private float spawnRange = 5f;

    private readonly Dictionary<string, ObjectPoolData> instantiatedObjectPools = new();

    private void Awake()
    {
        foreach(var objectPool in objectPools)
        {
            objectPool.Initialize();
            instantiatedObjectPools.Add(objectPool.PoolKey, objectPool);
        }

        StartCoroutine(SpawnEnemies());
    }

    public void InstantiateObject(string key, Vector3 position, Quaternion rotation)
    {
        ObjectPoolData objectPool = instantiatedObjectPools[key];

        if(objectPool == null)
        {
            return;
        }

        objectPool.ObjectPool.Instantiate(position, rotation);
    }

    private IEnumerator SpawnEnemies()
    {
        InstantiateObject(
            objectPools[Random.Range(0, objectPools.Count)].PoolKey,
            new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * spawnRange,
            Quaternion.identity
        );
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnEnemies());
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolData> objectPools;
    [SerializeField] private float spawnRange = 5f;
    [SerializeField] private float timeBetweenSpawns = 50f;

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
        float angle = UnityEngine.Random.Range(1f, 360f);
        Vector2 spawnPosition = new Vector2(
            Mathf.Cos(angle * Mathf.Rad2Deg) * spawnRange,
            Mathf.Sin(angle * Mathf.Rad2Deg) * spawnRange
        );

        InstantiateObject(
            objectPools[UnityEngine.Random.Range(0, objectPools.Count)].PoolKey,
            spawnPosition,
            Quaternion.identity
        );
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(SpawnEnemies());
    }
}
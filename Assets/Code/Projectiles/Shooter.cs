using UnityEngine;

[System.Serializable]
public class Shooter
{
    [SerializeField] private ObjectPool projectilesObjectPool;

    private ObjectPool runtimeObjectPool;

    public void Initialize(Transform parent)
    {
        runtimeObjectPool = Object.Instantiate(projectilesObjectPool);
        runtimeObjectPool.Initialize(parent);
    }

    public void Shoot(Vector2 origin, float angle)
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
        runtimeObjectPool.Instantiate(origin, rotation);
    }
}
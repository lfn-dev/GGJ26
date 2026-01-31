using UnityEngine;

[System.Serializable]
public class Shooter
{
    [SerializeField] private ObjectPoolChannel projectilesObjectPool;

    public void Shoot(Vector2 origin, float angle)
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
        projectilesObjectPool.OnInstantiate.Invoke(origin, rotation);
    }
}
using UnityEngine;

[System.Serializable]
public class Shooter
{
    [SerializeField] private ObjectPoolController projectilesObjectPool;

    public void Shoot(Transform origin, string projectileKey = "projectile")
    {
        projectilesObjectPool.InstantiateObject(projectileKey, origin.position, origin.rotation);
    }
}
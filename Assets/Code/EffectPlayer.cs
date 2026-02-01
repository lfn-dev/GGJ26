using UnityEngine;

[System.Serializable]
public class EffectPlayer
{
    [SerializeField] private ObjectPoolChannel effectObjectPool;

    public void PlayEffect(Vector2 origin)
    {
        effectObjectPool.OnInstantiate.Invoke(origin, Quaternion.identity);
    }
}
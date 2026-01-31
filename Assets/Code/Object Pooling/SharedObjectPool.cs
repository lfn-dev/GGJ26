using UnityEngine;

public class SharedObjectPool : MonoBehaviour
{
    [SerializeField] private ObjectPoolChannel objectPoolChannel;

    private ObjectPool ObjectPool { get { return objectPoolChannel.ObjectPool; } }

    private void Awake()
    {
        objectPoolChannel.OnInstantiate.AddListener(HandleInstantiate);
        ObjectPool.Initialize(transform);
    }

    private void OnDisable()
    {
        objectPoolChannel.OnInstantiate.RemoveListener(HandleInstantiate);
    }

    private void HandleInstantiate(Vector2 position, Quaternion rotation)
    {
        ObjectPool.Instantiate(position, rotation);
    }
}
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Object Pool Channel", menuName = "Object Pool/Channel")]
public class ObjectPoolChannel : ScriptableObject
{
    [SerializeField] private ObjectPool objectPool;
    public ObjectPool ObjectPool { get { return objectPool; } }

    [HideInInspector] public UnityEvent<Vector2, Quaternion> OnInstantiate;
}
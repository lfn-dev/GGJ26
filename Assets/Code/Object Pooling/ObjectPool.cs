using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Pool", menuName = "Game Data/Object Pool")]
public class ObjectPool : ScriptableObject
{
    [SerializeField] private PoolableGameObject prefabInstance;
    [SerializeField] private int instancesCount = 100;
    
    private Stack<PoolableGameObject> instances = new();

    public void Initialize(Transform instancesParent)
    {
        for (int i = 0; i < instancesCount; i++)
        {
            PoolableGameObject instance = Instantiate(prefabInstance);
            instance.transform.SetParent(instancesParent);
            instance.Disable();
            instances.Push(instance);
        }
    }

    public void Instantiate(Vector3 position, Quaternion rotation)
    {
        PoolableGameObject instance = instances.Pop();

        if (instance == null)
        {
            Debug.LogError("ObjectPool has no more available instances");
            return;
        }

        instance.transform.position = position;
        instance.transform.rotation = rotation;
        instance.Instantiate();
        instance.OnDestroy += OnInstanceDestroyed;
    }

    private void OnInstanceDestroyed(PoolableGameObject instance)
    {
        instances.Push(instance);
        instance.OnDestroy -= OnInstanceDestroyed;
    }

}

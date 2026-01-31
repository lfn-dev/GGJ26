using UnityEngine;
using UnityEngine.Events;

public abstract class PoolableGameObject : MonoBehaviour
{
    public abstract void Instantiate();
    public abstract void Destroy();
    public abstract void Disable();

    public UnityAction<PoolableGameObject> OnDestroy;
}
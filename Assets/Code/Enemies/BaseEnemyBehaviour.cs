using UnityEngine;

public abstract class BaseEnemyBehaviour : ScriptableObject
{
    [SerializeField] protected Enemy Enemy;

    public abstract void Initialize(Enemy enemy);
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
}
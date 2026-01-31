using UnityEngine;

public abstract class BaseEnemyBehaviour : ScriptableObject
{
    protected Enemy enemy;

    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
}
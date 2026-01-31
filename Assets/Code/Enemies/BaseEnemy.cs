using UnityEngine;

public abstract class BaseEnemy : PoolableGameObject
{
    [SerializeField] private EventRaiser OnEnemyDefeated;

    public override void Destroy()
    {
        OnEnemyDefeated.RaiseEvent();
        OnDestroy?.Invoke(this);
    }

    public override void Instantiate()
    {
        gameObject.SetActive(true);
    }
    
    public override void Disable()
    {
        gameObject.SetActive(false);
    }
}
using UnityEngine;

public abstract class BaseEnemy : PoolableGameObject
{
    [SerializeField] private EventChannel OnEnemyDefeated;
    [SerializeField] private Enemy enemy;
    [SerializeField] private BaseEnemyBehaviour behaviour;
    private BaseEnemyBehaviour runtimeBehaviour;

    public override void Instantiate()
    {
        gameObject.SetActive(true);
        runtimeBehaviour = Instantiate(behaviour);
        runtimeBehaviour?.Initialize(enemy);
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    public override void Setup()
    {
        gameObject.SetActive(false);
    }

    public override void Destroy()
    {
        OnDestroy.Invoke(this);
        OnEnemyDefeated.RaiseEvent();
    }

    private void Update()
    {
        runtimeBehaviour?.OnUpdate();
    }

    private void FixedUpdate()
    {
        runtimeBehaviour?.OnFixedUpdate();
    }
}
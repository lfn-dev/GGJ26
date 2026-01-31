using UnityEngine;

public abstract class BaseEnemy : PoolableGameObject
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private BaseEnemyBehaviour behaviour;

    public override void Instantiate()
    {
        gameObject.SetActive(true);
        behaviour.Initialize(enemy);
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        behaviour?.OnUpdate();
    }

    private void FixedUpdate()
    {
        behaviour?.OnFixedUpdate();
    }
}
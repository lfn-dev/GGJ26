using UnityEngine;

public class BasicEnemy : BaseEnemy, IEnemyDamageable
{
    [SerializeField] protected int health = 1;

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            Destroy();
        }
    }

    public override void Instantiate()
    {
        base.Instantiate();
        enabled = true;
    }
}
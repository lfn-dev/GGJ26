using UnityEngine;

public class BasicEnemy : BaseEnemy, IEnemyDamageable
{
    [SerializeField] protected int health = 1;
    protected int currentHealth = 1;

    public void DealDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Destroy();
        }
    }

    public override void Instantiate()
    {
        base.Instantiate();
        currentHealth = health;
        enabled = true;
    }
}
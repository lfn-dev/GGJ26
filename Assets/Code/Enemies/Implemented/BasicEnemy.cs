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
            audioPlayer.PlaySound("death");
            effectPlayer.PlayEffect(transform.position);
            Destroy();
        } else
        {
            audioPlayer.PlaySound("damage");
        }
    }

    public override void Instantiate()
    {
        base.Instantiate();
        currentHealth = health;
        enabled = true;
    }
}
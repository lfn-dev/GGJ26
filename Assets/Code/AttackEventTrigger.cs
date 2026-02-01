using UnityEngine;

public class AttackEventTrigger : MonoBehaviour, IEnemyDamageable
{
    [SerializeField] private EventRaiser OnEventRaised;

    public void DealDamage(int damageAmount)
    {
        OnEventRaised.RaiseEvent();
        gameObject.SetActive(false);
    }
}
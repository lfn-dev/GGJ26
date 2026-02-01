using UnityEngine;

public class StatIncreaser : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private EventRaiser OnBuffSelected;

    public void IncreaseMovementSpeed(float amount)
    {
        playerStats.movSpeed.AddValue(amount);
        OnBuffSelected.RaiseEvent();
    }

    public void IncreaseProjectileRate(float amount)
    {
        playerStats.shootsCooldown.AddValue(-amount);
        OnBuffSelected.RaiseEvent();
    }

    public void IncreaseDashDistance(float amount)
    {
        playerStats.dashDistance.AddValue(amount);
        OnBuffSelected.RaiseEvent();
    }

    public void IncreaseDamage(float amount)
    {
        playerStats.atkDmg.AddValue(amount);
        OnBuffSelected.RaiseEvent();
    }
}

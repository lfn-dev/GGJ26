using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private Image lifebar;

    private void Update()
    {
        lifebar.fillAmount = playerStats.health.value / playerStats.initialHealth;
    }
}
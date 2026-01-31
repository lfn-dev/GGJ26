using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "ScriptableObjects/PlayerStat", order = 1)]

public class PlayerStats : CharacterStats
{

    [Header("Player Specific Stats")]
    public Stat dashDistance;
    public Stat dashSpeed;
    public Stat turnSpeed;
    
}
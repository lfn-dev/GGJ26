using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat", menuName = "ScriptableObjects/PlayerStat", order = 1)]

public class PlayerStats : CharacterStats
{
    [Header("Player Specific Stats")]
    public Stat dashDistance;
    public Stat dashSpeed;
    public Stat turnSpeed;

    public Stat shootsCooldown;

    public override string ToString()
    {
        Stat[] statList = new Stat[] { health, movSpeed, atkSpeed, atkDmg, dashDistance, dashSpeed, turnSpeed};
        
        string retString = "";
        foreach (Stat st in statList)
        {
            retString += st.ToString();
        }

        return retString;
    }
    
}
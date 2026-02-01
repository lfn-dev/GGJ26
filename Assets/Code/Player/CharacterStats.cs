using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStat", menuName = "ScriptableObjects/Stat", order = 1)]

public class CharacterStats : ScriptableObject
{
    public Stat health;
    public int initialHealth = 100;

    [Tooltip("Invencible time (in seconds) after getting hitted")]
    public float invencibleTime = 1;
    
    public Stat movSpeed;
    public Stat atkSpeed;
    public Stat atkDmg;

    public override string ToString()
    {
        Stat[] statList = new Stat[] { health, movSpeed, atkSpeed, atkDmg };
        
        string retString = "";
        foreach (Stat st in statList)
        {
            retString += st.ToString();
        }

        return retString;
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "CharacterStat", menuName = "ScriptableObjects/Stat", order = 1)]

public class CharacterStats : ScriptableObject
{
    public int maxHealth = 100;
    public int initialHealth = 100;

    [Tooltip("Invencible time (in seconds) after getting hitted")]
    public float invencibleTime;

    public float  movSpeed = 5;
    public float atkSpeed = 5;
    public float atkDmg = 5;
    
}
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "CharacterStat", menuName = "ScriptableObjects/Stat", order = 1)]

public class CharacterStats : ScriptableObject
{
    [SerializeField] private int health;
    
    [Tooltip("Should life be clamped at a maximum value?")]
    public bool hasMaxLife;

    [Tooltip("If \"hasMaxLife\" is set to true, this value will be used as the maximum")]
    public int maxLife;

    [Tooltip("Invencible time (in seconds) after getting hitted")]
    public float invencibleTime;

    public float  movSpeed = 5;
    public float atkSpeed = 5;
    public float atkDmg = 5;
    
}
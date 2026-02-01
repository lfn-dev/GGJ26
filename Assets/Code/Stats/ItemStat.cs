using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStat : MonoBehaviour
{
    public enum StatName
    {
        Health, 
        MovSpeed, 
        AtkSpeed, 
        AtkDmg, 
        DashDistance, 
        DashSpeed,
        TurnSpeed,
        ProjectileCount,
    }

    [System.Serializable]
    public struct StatDescription
    {
        public Sprite icon;
        public StatName statName;
    }

    public string itemName;

    [Space]
    public PlayerStats statsModifier;

    [SerializeField]
    public StatDescription[] statDescriptions;

    public int StatCount()
    {
        Stat[] statList = new Stat[] { 
            statsModifier.health, 
            statsModifier.movSpeed, 
            statsModifier.atkSpeed, 
            statsModifier.atkDmg, 
            statsModifier.dashDistance, 
            statsModifier.dashSpeed, 
            statsModifier.turnSpeed
        };

        int count = 0;

        foreach (Stat stat in statList)
        {
            if(stat.value != 0) count++;
            if(stat.min != 0) count++;
            if(stat.max != 0) count++;
        }

        return count;
    }

    public Sprite GetStatSpriteFromEnum(StatName name)
    {
        foreach (StatDescription statDesc in statDescriptions)
        {
            if(statDesc.statName == name) return statDesc.icon;
        }

        Debug.LogWarning($"StatName {name} not found in StatDescription list. Returning Deafult");
        return statDescriptions[0].icon;
    }

    public List<(Stat,StatName)> GetActiveStats()
    {
        List<(Stat,StatName)> activeStats = new List<(Stat, StatName)>();

        Stat stat;

        stat = statsModifier.health;
        if(stat.NonZero()) activeStats.Add((stat,StatName.Health));

        stat = statsModifier.movSpeed;
        if(stat.NonZero()) activeStats.Add((stat,StatName.MovSpeed));

        stat = statsModifier.atkSpeed;
        if(stat.NonZero()) activeStats.Add((stat,StatName.AtkSpeed));

        stat = statsModifier.atkDmg;
        if(stat.NonZero()) activeStats.Add((stat,StatName.AtkDmg));

        stat = statsModifier.dashSpeed;
        if(stat.NonZero()) activeStats.Add((stat,StatName.DashSpeed));

        stat = statsModifier.dashDistance;
        if(stat.NonZero()) activeStats.Add((stat,StatName.DashDistance));

        stat = statsModifier.turnSpeed;
        if(stat.NonZero()) activeStats.Add((stat,StatName.TurnSpeed));

        return activeStats;
    }
}

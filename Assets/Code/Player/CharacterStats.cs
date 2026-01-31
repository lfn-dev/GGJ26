using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStat", menuName = "ScriptableObjects/Stat", order = 1)]

public class CharacterStats : ScriptableObject
{

    [System.Serializable]
    public class Stat
    {
        public string name;
        
        public float value;
        public float min;
        public float max;
        
        public Stat(string name, float value, float min, float max)
        {
            this.name = name;
            this.value=value;
            this.min=min;
            this.max=max;
        }

        public void SetValue(float value){this.value=Mathf.Clamp(value,this.min,this.max);}
        public void AddValue(float value){this.value+=Mathf.Clamp(value,this.min,this.max);}

    }

    public Stat health;
    public int initialHealth = 100;

    [Tooltip("Invencible time (in seconds) after getting hitted")]
    public float invencibleTime = 1;
    
    public Stat  movSpeed;
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
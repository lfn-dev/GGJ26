using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStat", menuName = "ScriptableObjects/Stat", order = 1)]

public class CharacterStats : ScriptableObject
{

    [System.Serializable]
    public class Stat
    {
        
        public int value;
        public int min;
        public int max;
        
        public Stat(int value, int min, int max)
        {
            this.value=value;
            this.min=min;
            this.max=max;
        }

        public void SetValue(int value){this.value=(int) Mathf.Clamp(value,this.min,this.max);}
        public void AddValue(int value){this.value+=(int) Mathf.Clamp(value,this.min,this.max);}

    }

    public Stat health;
    public int initialHealth = 100;

    [Tooltip("Invencible time (in seconds) after getting hitted")]
    public float invencibleTime = 1;
    
    public Stat  movSpeed;
    public Stat atkSpeed;
    public Stat atkDmg;
    
}
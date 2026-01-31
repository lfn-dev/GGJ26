using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStat", menuName = "ScriptableObjects/Stat", order = 1)]

public class CharacterStats : ScriptableObject
{

    [System.Serializable]
    public class Stat
    {
        
        public float value;
        public float min;
        public float max;
        
        public Stat(float value, float min, float max)
        {
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
    
}
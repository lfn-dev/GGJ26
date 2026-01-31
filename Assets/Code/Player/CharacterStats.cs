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

        public Stat(float value, float min, float max) : this("", value, min, max)
        {
            // O corpo pode ficar vazio, pois o outro construtor já fez tudo.
        }


        public static Stat operator +(Stat a, Stat b)
        {
            // 1. Soma os atributos individualmente
            float newValue = a.value + b.value;
            float newMin = a.min + b.min;
            float newMax = a.max + b.max;

            // 2. Cria e retorna a NOVA instância
            // (Operadores nunca devem modificar os objetos originais 'a' ou 'b')
            Stat result = new Stat(newValue, newMin, newMax);
            
            // 3. Opcional: Garante que o novo valor respeite os novos limites
            // result.value = Mathf.Clamp(result.value, result.min, result.max);
            return result;
        }

        public void SetValue(float value){this.value=Mathf.Clamp(value,this.min,this.max);}
        public void AddValue(float value){this.value+=Mathf.Clamp(value,this.min,this.max);}

        public override string ToString()
        {
            string retString = "";

            if(value != 0) retString += name + ":" + value.ToString() + "\n";
            if(min != 0) retString += "Min " + name + ":" + min.ToString();
            if(max != 0) retString += "Max " + name + ":" + max.ToString();

            return retString;

        }

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
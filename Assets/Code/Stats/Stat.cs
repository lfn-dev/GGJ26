using UnityEngine;

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
        this.value = value;
        this.min = min;
        this.max = max;
    }

    public void SetValue(float value) { this.value = Mathf.Clamp(value, min, max); }
    public void AddValue(float value) { this.value += value; }

    public bool NonZero(){return value != 0 || min != 0 || max != 0;}

    public override string ToString()
    {
        string valString = ((value>0) ? "+":"") + value.ToString();
        string valMin = ((min>0) ? "+":"") + min.ToString();
        string valMax = ((max>0) ? "+":"") + max.ToString();
        string fullStr = ((value != 0) ? valString : "") +
        ((min != 0) ? " | MAX: " + valMin : "") + 
        ((max != 0) ? " | MIN: " +  valMax : "");
        return fullStr;
    }

}
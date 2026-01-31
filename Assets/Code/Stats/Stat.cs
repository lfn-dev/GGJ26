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
    public void AddValue(float value) { this.value += Mathf.Clamp(value, min, max); }

}
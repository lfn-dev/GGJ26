using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioGroup
{
    [SerializeField] private List<AudioClip> audios;
    
    public AudioClip GetRandomAudio()
    {
        return audios[Random.Range(0, audios.Count)];
    }
}
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioChannelTransmissor
{
    [SerializeField] private List<AudioChannel> audioChannels;

    public void PlaySound(string audioChannelName)
    {
        AudioChannel audioChannel = audioChannels.Find((audio) => audio.ChannelName == audioChannelName);

        if (audioChannel == null)
        {
            return;
        }

        audioChannel.Play();
    }
}
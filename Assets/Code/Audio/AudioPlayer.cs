using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioChannel> audioChannels;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        foreach(AudioChannel audioChannel in audioChannels)
        {
            audioChannel.OnPlayAudioChannel += PlayChannel;
        }
    }

    private void OnDisable()
    {
        foreach(AudioChannel audioChannel in audioChannels)
        {
            audioChannel.OnPlayAudioChannel -= PlayChannel;
        }
    }

    private void PlayChannel(AudioGroup audioGroup)
    {
        audioSource.PlayOneShot(audioGroup.GetRandomAudio());
    }
}
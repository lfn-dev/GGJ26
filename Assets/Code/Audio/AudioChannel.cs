using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Audio Channel", menuName = "Audio/Audio Channel")]
public class AudioChannel : ScriptableObject
{
    [SerializeField] private string channelName;
    public string ChannelName { get { return channelName; } }
    [SerializeField] private AudioGroup audioGroup;
    
    public UnityAction<AudioGroup> OnPlayAudioChannel;

    public void Play()
    {
        OnPlayAudioChannel?.Invoke(audioGroup);
    }
}
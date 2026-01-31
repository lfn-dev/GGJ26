using UnityEngine;

[System.Serializable]
public class EventRaiser {
    [SerializeField] private EventChannel eventChannel;

    public void RaiseEvent()
    {
        eventChannel.RaiseEvent();
    }
}
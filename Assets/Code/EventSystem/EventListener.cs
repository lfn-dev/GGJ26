using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour {
    [Header("Event Channel")]
    [SerializeField] private EventChannel eventChannel;

    [Header("Response")]
    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        eventChannel.AddListener(response.Invoke);
    }

    private void OnDisable()
    {
        eventChannel.RemoveListener(response.Invoke);
    }
}
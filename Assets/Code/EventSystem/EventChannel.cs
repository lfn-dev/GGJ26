
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event Channel", menuName = "Events/Event Channel")]
public class EventChannel : ScriptableObject
{
    private Action Event;

    public void RaiseEvent()
    {
        Event();
    }

    public void AddListener(Action action)
    {
        Event += action;
    }

    public void RemoveListener(Action action)
    {
        Event += action;
    }
}
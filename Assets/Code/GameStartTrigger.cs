using UnityEngine;

public class GameStartTrigger : MonoBehaviour
{
    [SerializeField] private EventRaiser OnGameStart;

    private void Start()
    {
        OnGameStart.RaiseEvent();
    }
}
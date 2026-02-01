using UnityEngine;
using UnityEngine.UI;

public class MaskSwitchSystem : MonoBehaviour
{
    [SerializeField] private EventRaiser OnMaskSwitch;
    [SerializeField] private float decreaseRate = 0.5f;
    [SerializeField] private MaskUI maskUI;

    private float maskMeter = 0f;

    private void Awake()
    {
        maskUI.Initialize();
    }

    public void IncreaseMaskMeter(float amount)
    {
        maskMeter += amount;
        if (maskMeter >= 10f)
        {
            maskUI.PlayAnimation();
        }
    }

    public void RaiseEvent()
    {
        maskMeter = 0f;
        OnMaskSwitch.RaiseEvent();
        maskUI.SwapActiveMaskUI();
    }

    private void Update()
    {
        maskUI.UpdateFill(maskMeter / 10f);
        if (maskMeter > 0f)
        {
            maskMeter -= Time.deltaTime * decreaseRate;
        }
    }
}

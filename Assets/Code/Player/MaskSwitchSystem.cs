using UnityEngine;
using UnityEngine.UI;

public class MaskSwitchSystem : MonoBehaviour
{
    [SerializeField] private EventRaiser OnMaskSwitch;
    [SerializeField] private float decreaseRate = 0.5f;
    [SerializeField] private Image maskMeterBar;

    private float maskMeter = 0f;

    public void IncreaseMaskMeter(float amount)
    {
        maskMeter += amount;

        if(maskMeter >= 10f)
        {
            maskMeter = 0f;
            OnMaskSwitch.RaiseEvent();
        }
    }

    private void Update()
    {
        maskMeterBar.fillAmount = maskMeter / 10f;
        if (maskMeter > 0f)
        {
            maskMeter -= Time.deltaTime * decreaseRate;
        }
    }
}

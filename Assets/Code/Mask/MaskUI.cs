using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MaskUI
{
    [SerializeField] private Image leftMask;
    [SerializeField] private Image rightMask;
    [SerializeField] private Animator animator;

    private Image activeMask;

    public void Initialize()
    {
        activeMask = rightMask;
        SwapActiveMaskUI();
    }

    public void SwapActiveMaskUI()
    {
        activeMask.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        if (activeMask == leftMask)
        {
            activeMask = rightMask;
        } else
        {
            activeMask = leftMask;
        }

        activeMask.rectTransform.localScale = Vector3.one;
    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Play");
    }

    public void UpdateFill(float fillAmount)
    {
        activeMask.fillAmount = fillAmount;
    }
}
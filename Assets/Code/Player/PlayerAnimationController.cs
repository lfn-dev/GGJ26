using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator flipAnimation;

    public void Flip(bool left)
    {
        flipAnimation.SetBool("left", left);
    }
}

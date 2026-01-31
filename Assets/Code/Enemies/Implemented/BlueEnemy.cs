using UnityEngine;

public class BlueEnemy : BaseEnemy
{
    public override void Destroy()
    {
        OnDestroy.Invoke(this);
    }

    public override void Instantiate()
    {
        base.Instantiate();
        Debug.Log("Dame un grrr!");
        Invoke("Destroy", 2f);
    }
}
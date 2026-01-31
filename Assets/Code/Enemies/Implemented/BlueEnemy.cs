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
        Invoke("Destroy", 5f);
    }
}
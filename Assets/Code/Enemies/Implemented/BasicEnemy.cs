using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    public override void Destroy()
    {
        OnDestroy.Invoke(this);
    }

    public override void Instantiate()
    {
        base.Instantiate();
        enabled = true;

        Invoke("Destroy", 20f);
    }

    public override void Disable()
    {
        base.Instantiate();
        enabled = false;
    }

    public override void Setup()
    {

    }
}
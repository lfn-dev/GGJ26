using UnityEngine;

public class RedEnemy : BaseEnemy
{
    public override void Destroy()
    {
        OnDestroy.Invoke(this);
    }

    public override void Instantiate()
    {
        base.Instantiate();
        Debug.Log("Un grrr!");
        Invoke("Destroy", 3f);
    }
}
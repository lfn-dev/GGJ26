using System.Collections;
using UnityEngine;

public class GreenEnemy : BaseEnemy
{
    public override void Destroy()
    {
        OnDestroy.Invoke(this);
    }

    public override void Instantiate()
    {
        base.Instantiate();
        Debug.Log("Un que?");
        Invoke("Destroy", 5f);
    }
}
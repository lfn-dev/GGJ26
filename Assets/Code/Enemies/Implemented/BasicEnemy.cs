using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    public override void Instantiate()
    {
        base.Instantiate();
        enabled = true;
    }
}
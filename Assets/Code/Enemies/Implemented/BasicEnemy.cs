using UnityEngine;

public class BasicEnemy : BaseEnemy
{
    [SerializeField] private GameObject body;

    public override void Destroy()
    {
        OnDestroy.Invoke(this);
    }

    public override void Instantiate()
    {
        base.Instantiate();
        body.SetActive(true);
        Invoke("Destroy", 5f);
    }

    public override void Disable()
    {
        body.SetActive(false);
    }
}
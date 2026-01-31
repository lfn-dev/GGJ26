using UnityEngine;

public class Projectile : PoolableGameObject
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private float movementSpeed;

    public override void Destroy()
    {
        OnDestroy.Invoke(this);
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    public override void Instantiate()
    {
        gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        movementController.Move(transform.up * movementSpeed);
    }
}
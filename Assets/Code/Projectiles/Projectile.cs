using UnityEngine;

public class Projectile : PoolableGameObject
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float maxTimeAlive = 5f;

    private float timeAlive = 0f;

    public override void Destroy()
    {
        OnDestroy?.Invoke(this);
        Disable();
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    public override void Instantiate()
    {
        gameObject.SetActive(true);
        timeAlive = maxTimeAlive;
    }

    public override void Setup()
    {
    }

    private void FixedUpdate()
    {
        movementController.Move(transform.up * movementSpeed);
    }

    private void Update()
    {
        timeAlive -= Time.deltaTime;

        if (timeAlive <= 0f)
        {
            Destroy();
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable hit = collider.gameObject.GetComponent<IDamageable>();

        if (hit != null)
        {
            Destroy();
            hit.DealDamage(1);
        }
    }
}
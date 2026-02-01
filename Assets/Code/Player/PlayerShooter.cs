using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float cooldownBetweenShoots = 0.2f;
    [SerializeField] private ObjectPool projectileObjectPool;
    [SerializeField] private Transform poolParent;

    private float timeSinceLastShoot = 0f;

    private void Awake()
    {
        projectileObjectPool.Initialize(poolParent);
    }

    private void Update()
    {
        timeSinceLastShoot -= Time.deltaTime;
    }

    public void Shoot(Vector2 origin, Quaternion direction)
    {
        if(timeSinceLastShoot > 0f)
        {
            return;
        }

        timeSinceLastShoot = cooldownBetweenShoots;
        projectileObjectPool.Instantiate(origin, direction);
    }
}
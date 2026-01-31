using UnityEngine;

[CreateAssetMenu(fileName = "New Lurk Player Enemy Behaviour", menuName = "Enemies Behaviour/Lurk Player Behaviour")]
public class LurkPlayerEnemyBehaviour : BaseEnemyBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float minDistanceFromPlayer = 2f;

    [Header("Shoot Settings")]
    [SerializeField] private float cooldownBetweenSpreads = 5f;
    [SerializeField] private int projectilesAmount = 4;
    [SerializeField] private float intervalBetweenShoots = 0.1f;

    private Transform target;
    private float timeSinceLastShoot = 0f;
    private float timeSinceLastSpread = 0f;
    private int remainingProjectiles = 0;
    private Vector2 movementDirection;

    public override void Initialize(Enemy enemy)
    {
        Enemy = enemy;
        target = FindFirstObjectByType<PlayerController>().transform;
        timeSinceLastShoot = intervalBetweenShoots;
        timeSinceLastSpread = cooldownBetweenSpreads;
        remainingProjectiles = 0;
    }

    public override void OnFixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        if (Vector2.Distance(Enemy.Transform.position, target.position) >= minDistanceFromPlayer)
        {
            Enemy.MovementController.Move(movementDirection * movementSpeed);
        }
        else
        {
            Enemy.MovementController.Move(Vector2.zero);
        }
    }

    public override void OnUpdate()
    {
        MoveRoutine();
        ShootRoutine();
    }

    private void MoveRoutine()
    {
        if (target == null)
        {
            return;
        }

        movementDirection = Vector2.Lerp(movementDirection, (target.position - Enemy.Transform.position).normalized, Time.deltaTime);
    }

    private void ShootRoutine()
    {
        if (timeSinceLastSpread > 0f && remainingProjectiles == 0)
        {
            timeSinceLastSpread -= Time.deltaTime;
            if(timeSinceLastSpread <= 0f)
            {
                remainingProjectiles = projectilesAmount;
            }
            return;
        }

        if (timeSinceLastShoot <= 0f)
        {
            timeSinceLastShoot = intervalBetweenShoots;
            remainingProjectiles--;

            Enemy.Shooter.Shoot(Enemy.Transform.position, 20f * remainingProjectiles);

            if (remainingProjectiles == 0)
            {
                timeSinceLastSpread = cooldownBetweenSpreads;
            }
        }
        else
        {
            timeSinceLastShoot -= Time.deltaTime;
        }

    }
}
using UnityEngine;

[CreateAssetMenu(fileName = "New Lurk Player Enemy Behaviour", menuName = "Enemies Behaviour/Lurk Player Behaviour")]
public class LurkPlayerEnemyBehaviour : BaseEnemyBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float minDistanceFromPlayer = 2f;
    [SerializeField] private float minTimeToChangeRotation = 1f;
    [SerializeField] private float maxTimeToChangeRotation = 5f;

    [Header("Shoot Settings")]
    [SerializeField] private float cooldownBetweenSpreads = 5f;
    [SerializeField] private int projectilesAmount = 4;
    [SerializeField] private float intervalBetweenShoots = 0.1f;

    private Transform target;
    private float timeSinceLastShoot = 0f;
    private float timeSinceLastSpread = 0f;
    private int remainingProjectiles = 0;
    private Vector2 movementDirection;
    private Vector2 newMovementDirection;
    private float timeToChangeRotation = 0f;
    private float rotateDirection = 1f;

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
        
        Enemy.MovementController.Move(movementDirection * movementSpeed);
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

        
        timeToChangeRotation -= Time.deltaTime;

        if(timeToChangeRotation <= 0f)
        {
            rotateDirection *= -1f;
            timeToChangeRotation = Random.Range(minTimeToChangeRotation, maxTimeToChangeRotation);
        }
        
        newMovementDirection = (target.position - Enemy.Transform.position).normalized;

        if (Vector2.Distance(Enemy.Transform.position, target.position) < minDistanceFromPlayer)
        {
            newMovementDirection = Vector2.Perpendicular(newMovementDirection) * rotateDirection;
        }

        movementDirection = Vector2.Lerp(movementDirection, newMovementDirection, Time.deltaTime);
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
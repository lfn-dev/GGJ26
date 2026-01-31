using UnityEngine;

[CreateAssetMenu(fileName = "New Follow Player Enemy Behaviour", menuName = "Enemies Behaviour/Follow Player Behaviour")]
public class FollowPlayerEnemyBehaviour : BaseEnemyBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float minDistanceFromPlayer = 2f;
    [SerializeField] private float minTimeToChangeRotation = 1f;
    [SerializeField] private float maxTimeToChangeRotation = 5f;

    [Header("Shoot Settings")]
    [SerializeField] private float cooldownBetweenShoots = 1f;

    private Transform target;
    private Vector2 movementDirection;
    private Vector2 newMovementDirection;

    private float rotateDirection = 1f;

    private float timeSinceLastShot = 0f;
    private float timeToChangeRotation = 0f;

    public override void Initialize(Enemy enemy)
    {
        Enemy = enemy;
        target = FindFirstObjectByType<PlayerController>().transform;
        timeSinceLastShot = cooldownBetweenShoots;
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
        timeSinceLastShot -= Time.deltaTime;
        if (timeSinceLastShot <= 0f)
        {
            timeSinceLastShot = cooldownBetweenShoots;

            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;

            Enemy.Shooter.Shoot(Enemy.Transform.position, angle);
        }
    }
}
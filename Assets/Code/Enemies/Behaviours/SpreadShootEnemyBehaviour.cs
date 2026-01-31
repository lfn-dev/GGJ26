using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spread Shoot Enemy Behaviour", menuName = "Enemies Behaviour/Spread Shoot and Dash")]
public class SpreadShootEnemyBehaviour : BaseEnemyBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] private float timeBetweenDashes = 1.5f;
    [SerializeField] private float dashVelocity = 5f;
    [SerializeField] private float friction = 10f;
    [SerializeField] private float angleVariation = 45f;

    [Header("Shoot Settings")]
    [SerializeField] private int projectilesAmount = 4;
    [SerializeField] private float intervalBetweenShoots = 0.1f;

    private Transform target;
    private float timeSinceLastDash = 0f;
    private float timeSinceLastShoot = 0f;
    private float currentVelocity = 0f;
    private int remainingProjectiles = 0;

    private Vector2 movementDirection;

    public override void Initialize(Enemy enemy)
    {
        Enemy = enemy;
        target = FindFirstObjectByType<PlayerController>().transform;
        timeSinceLastDash = 0f;
        currentVelocity = 0f;
        remainingProjectiles = 0;
    }

    public override void OnFixedUpdate()
    {
        if (currentVelocity > 0f)
        {
            Enemy.MovementController.Move(movementDirection * currentVelocity);
        }
    }

    public override void OnUpdate()
    {
        MoveRoutine();
        ShootRoutine();
    }

    private void MoveRoutine()
    {
        timeSinceLastDash -= Time.deltaTime;

        if (timeSinceLastDash <= 0f)
        {
            timeSinceLastDash = timeBetweenDashes;
            remainingProjectiles = projectilesAmount;
            currentVelocity = dashVelocity;

            Vector2 movementDirectionNormalized = (target.position - Enemy.Transform.position).normalized;

            float currentAngleMovement = Mathf.Atan2(movementDirectionNormalized.y, movementDirectionNormalized.x);

            currentAngleMovement += UnityEngine.Random.Range(-angleVariation, angleVariation) * Mathf.Deg2Rad;

            movementDirection = new Vector2(
                Mathf.Cos(currentAngleMovement),
                Mathf.Sin(currentAngleMovement)
            );
        }
        else
        {
            currentVelocity -= Time.deltaTime * friction;
        }
    }

    private void ShootRoutine()
    {
        if (remainingProjectiles > 0)
        {
            if (timeSinceLastShoot <= 0f)
            {
                timeSinceLastShoot = intervalBetweenShoots;
                remainingProjectiles--;

                Vector2 movementDirectionNormalized = (target.position - Enemy.Transform.position).normalized;
                float angle = Mathf.Atan2(movementDirectionNormalized.y, movementDirectionNormalized.x) * Mathf.Rad2Deg;

                Enemy.Shooter.Shoot(Enemy.Transform.position, angle + (90f / projectilesAmount * remainingProjectiles));
            }
            else
            {
                timeSinceLastShoot -= Time.deltaTime;
            }
        }
    }
}

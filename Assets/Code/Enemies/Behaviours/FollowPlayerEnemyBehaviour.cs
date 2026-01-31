using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "New Follow Player Enemy Behaviour", menuName = "Enemies Behaviour/Follow Player Behaviour")]
public class FollowPlayerEnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float cooldownBetweenShoots = 1f;

    private Transform target;
    private Vector2 movementDirection;
    private float timeSinceLastShot = 0f;

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
        if (target == null)
        {
            return;
        }

        movementDirection = (target.position - Enemy.Transform.position).normalized;
        
        timeSinceLastShot -= Time.deltaTime; 
        if (timeSinceLastShot <= 0f)
        {
            timeSinceLastShot = cooldownBetweenShoots;

            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            
            Enemy.Shooter.Shoot(Enemy.Transform.position, angle);
        }
    }
}
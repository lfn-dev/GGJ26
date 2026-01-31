using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Orbit Enemy Behaviour", menuName = "Enemies Behaviour/Orbit Behaviour")]
public class OrbitEnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float orbitSpeed = 1f;
    [SerializeField] private float cooldownBetweenSpreads = 5f;

    private float timeSinceLastSpread = 0f;
    private float currentAngleMovement = 0f;
    private float direction = 1f;

    public override void Initialize(Enemy enemy)
    {
        Enemy = enemy;
        timeSinceLastSpread = cooldownBetweenSpreads;
        direction = UnityEngine.Random.Range(0f, 1f) % 2 == 0 ? 1f : -1f;
        currentAngleMovement = Mathf.Atan2(Enemy.Transform.position.normalized.y, Enemy.Transform.position.normalized.x);
    }

    public override void OnFixedUpdate()
    {
        Vector2 movementDirection = new Vector2(
            Mathf.Cos(currentAngleMovement * Mathf.PI),
            Mathf.Sin(currentAngleMovement * Mathf.PI)
        );

        Enemy.MovementController.Move(movementDirection * movementSpeed);
    }

    public override void OnUpdate()
    {
        currentAngleMovement += Time.deltaTime * orbitSpeed * direction;
        timeSinceLastSpread -= Time.deltaTime;
        if (timeSinceLastSpread <= 0f)
        {
            timeSinceLastSpread = cooldownBetweenSpreads;

            float angle = 0f;

            Enemy.Shooter.Shoot(Enemy.Transform.position, angle);
        }
    }
}
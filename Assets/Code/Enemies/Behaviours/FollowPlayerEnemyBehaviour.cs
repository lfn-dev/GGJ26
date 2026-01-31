using UnityEngine;

[CreateAssetMenu(fileName = "New Follow Player Enemy Behaviour", menuName = "Enemies Behaviour/Follow Player Behaviour")]
public class FollowPlayerEnemyBehaviour : BaseEnemyBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    private Transform target;
    private Vector2 movementDirection;

    public override void Initialize(Enemy enemy)
    {
        Enemy = enemy;
        target = FindFirstObjectByType<PlayerController>().transform;
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
    }
}
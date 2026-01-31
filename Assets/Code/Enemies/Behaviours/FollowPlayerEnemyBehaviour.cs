using UnityEngine;

<<<<<<< HEAD
public class FollowPlayerEnemyBehaviour : BaseEnemyBehaviour
{
    private Transform target;

    public override void OnFixedUpdate()
    {
        throw new System.NotImplementedException();
=======
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
>>>>>>> 03f0aef (add: estrutura básica de comportamento de inimigos e base de comportamento de inimigo que segue)
    }

    public override void OnUpdate()
    {
<<<<<<< HEAD
        throw new System.NotImplementedException();
=======
        if (target == null)
        {
            return;
        }

        movementDirection = (target.position - Enemy.Transform.position).normalized;
>>>>>>> 03f0aef (add: estrutura básica de comportamento de inimigos e base de comportamento de inimigo que segue)
    }
}
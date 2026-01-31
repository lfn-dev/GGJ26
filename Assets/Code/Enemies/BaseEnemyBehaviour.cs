using UnityEngine;

public abstract class BaseEnemyBehaviour : ScriptableObject
{
<<<<<<< HEAD
    protected Enemy enemy;

    public void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
    }

=======
    [SerializeField] protected Enemy Enemy;

    public abstract void Initialize(Enemy enemy);
>>>>>>> 03f0aef (add: estrutura básica de comportamento de inimigos e base de comportamento de inimigo que segue)
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
}
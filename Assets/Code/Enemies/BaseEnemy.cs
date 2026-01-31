public abstract class BaseEnemy : PoolableGameObject
{
    public override void Instantiate()
    {
        gameObject.SetActive(true);
    }
    
    public override void Disable()
    {
        gameObject.SetActive(false);
    }
}
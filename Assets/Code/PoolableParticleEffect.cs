using UnityEngine;

public class PoolableParticleEffect : PoolableGameObject
{
    [SerializeField] private ParticleSystem particles;

    public override void Destroy()
    {
        OnDestroy.Invoke(this);
        gameObject.SetActive(false);
    }

    public override void Disable()
    {
        particles.Stop();
    }

    public override void Instantiate()
    {
        gameObject.SetActive(true);
        particles.Play();
    }

    public override void Setup()
    {
        particles.Stop();
    }

    private void OnParticleSystemStopped()
    {
        Destroy();
    }
}
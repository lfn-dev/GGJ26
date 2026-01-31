using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private ProjectileQeue projectileQeue = new ProjectileQeue();

    [SerializeField]
    public float atkSpeedMultiplier {get; private set;} = 0.8f;

    [SerializeField]
    public float dmgReduction  {get; private set;} = 0.75f;

    public int projectiles = 1;

    [Space]

    [SerializeField]
    private GameObject projectilePrefab;
    public Transform spawnPosition;

    [SerializeField]
    private PlayerStats stats;

    private Vector3 projectileDestination;

    public bool isShooting {get; private set;} = false;

    private void Start()
    {
        for (int i = 0; i < stats.maxProjectile.value; i++)
        {
            projectileQeue.addObj(Instantiate(projectilePrefab,spawnPosition.position,Quaternion.identity));
        }
    }

    private void FixedUpdate()
    {
        projectileQeue.UpdatePosition(spawnPosition.position);
    }

    public void Shoot(Vector3 lookDirection)
    {
        projectileQeue.Shoot(lookDirection);
    }
}

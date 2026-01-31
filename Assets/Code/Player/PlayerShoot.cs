using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    // private class ProjectileQeue
    // {
    //     List<GameObject> gameObjects = new List<GameObject>();
    //     List<bool> isActive = new List<bool>();
    //     List<float> timer = new List<float>();
    //     int index = 0;
    //     int maxIndex = 0;

    //     public addObj(GameObject obj)
    //     {
    //         gameObjects.Add(obj);
    //         isActive.Add(false);
    //         timer.Add(0.0f);
    //         maxIndex++;
    //     }
    // }

    // private ProjectileQeue projectileQeue = new ProjectileQeue();

    // [SerializeField]
    // public float atkSpeedMultiplier {get; private set;} = 0.8f;

    // [SerializeField]
    // public float dmgReduction  {get; private set;} = 0.75f;

    // public int projectiles = 1;

    // [Space]

    // [SerializeField]
    // private GameObject projectilePrefab;

    // [SerializeField]
    // private PlayerStats stats;

    // private Vector3 projectileDestination;

    // public bool isShooting {get; private set;} = false;

    // private void Start()
    // {

    //     dashTimeCount = 1.0f;
    //     lastAttackTime = Time.time;
    // }

    // private void FixedUpdate()
    // {
    //     if(dashTimeCount < 0.95f)
    //     {
    //         transform.position = Vector3.Lerp(transform.position, dashDestination, dashTimeCount);
    //         dashTimeCount += Time.deltaTime * stats.dashSpeed.value;
    //     }
    //     else
    //     {
    //         isDashing = false;
    //     }
    // }

    // public void Shoot(Vector3 lookDirection)
    // {
    //     if(Time.time - lastAttackTime > (1.0f/stats.atkSpeed.value))
    //     {
    //         dashTimeCount = 0.0f;
    //         lastAttackTime = Time.time;
    //         isDashing = true;
    //         dashDestination = transform.position + lookDirection.normalized * stats.dashDistance.value;
    //     }
    // }
}

using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    [SerializeField] private PlayerStats stats;


    private float dashTimeCount;
    private Vector3 dashDestination;
    private float lastAttackTime;

    public bool isDashing {get; private set;} = false;

    private void Start()
    {
        dashTimeCount = 1.0f;
        lastAttackTime = Time.time;
        stats ??= gameObject.GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        if(dashTimeCount < 0.95f)
        {
            transform.position = Vector3.Lerp(transform.position, dashDestination, dashTimeCount);
            dashTimeCount += Time.deltaTime * stats.dashSpeed.value;
        }
        else
        {
            isDashing = false;
        }
    }

    public void Dash(Vector3 lookDirection)
    {
        if(Time.time - lastAttackTime > (1.0f/stats.atkSpeed.value))
        {
            dashTimeCount = 0.0f;
            lastAttackTime = Time.time;
            isDashing = true;
            dashDestination = transform.position + lookDirection.normalized * stats.dashDistance.value;
        }
    }
}

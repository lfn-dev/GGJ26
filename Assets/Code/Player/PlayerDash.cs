using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    [SerializeField] private PlayerStats stats;
    [SerializeField] private Transform body;
    [SerializeField] private AudioChannelTransmissor audioChannel;

    private float dashTimeCount;
    private Vector3 dashDestination;
    private float lastAttackTime;

    public bool isDashing {get; private set;} = false;

    private void Start()
    {
        dashTimeCount = 1.0f;
        lastAttackTime = Time.time;
    }

    private void FixedUpdate()
    {
        if(dashTimeCount < 0.95f)
        {
            body.transform.position = Vector3.Lerp(body.transform.position, dashDestination, dashTimeCount);
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
            dashDestination = body.transform.position + lookDirection.normalized * stats.dashDistance.value;
            audioChannel.PlaySound("dash");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IEnemyDamageable enemy = collision.gameObject.GetComponent<IEnemyDamageable>();
        if (enemy != null && isDashing)
        {
            enemy.DealDamage((int)stats.atkDmg.value);
        }
    }
}

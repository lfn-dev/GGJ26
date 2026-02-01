using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;

    public float currentHealth {get; private set;}

    private float lastTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastTime = Time.time;
        currentHealth = stats.initialHealth;
    }

    public void Hit(int value){
        if(Time.time - lastTime > stats.invencibleTime){
            AddHealth(-value);
            
            // foreach (Animator anim in animators)
            // {
            //     anim.SetTrigger("Hitted");
            // }

            Debug.Log("Hit");
            //AudioManager.Instance.PlayClip(playerHit);

            lastTime = Time.time;
        }
    }

    public void AddHealth(int amount){
        currentHealth += amount;
        if(currentHealth <= stats.health.min){
            // foreach (Animator anim in animators)
            // {
            //     //anim.SetTrigger("Dead");
            // }

            Debug.Log("Dead");
            //StartCoroutine(LevelManager.Instance.EndGame());
        }
        else if(currentHealth > stats.health.max){
                currentHealth = stats.health.max;
        }
    }

    public void AddStat(PlayerStats additionalStats)
    {
    }
}

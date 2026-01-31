using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;

    private int currentHealth {public get; set;}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastTime = Time.time;
        currentHealth = stats.initialHealth;
    }

    public void Hit(int value){
        if(Time.time - lastTime > invencibleTime){
            AddLife(-value);
            
            foreach (Animator anim in animators)
            {
                Console.Log("Hit");
                //anim.SetTrigger("Hitted");
            }

            //AudioManager.Instance.PlayClip(playerHit);

            lastTime = Time.time;
        }
    }

    public void AddLife(int amount){
        currentHealth += amount;
        if(currentHealth <= 0){
            foreach (Animator anim in animators)
            {
                Console.Log("Dead");
                //anim.SetTrigger("Dead");
            }

            //StartCoroutine(LevelManager.Instance.EndGame());
        }
        else if(currentHealth > stats.maxHealth){
                currentHealth = stats.maxHealth;
        }
    }
}

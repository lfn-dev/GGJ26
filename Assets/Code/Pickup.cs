using UnityEngine;

public class Pickup : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<StatManager>().AddHealth(10);
            gameObject.SetActive(false);
        }
    }
}

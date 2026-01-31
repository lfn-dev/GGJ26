using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Pickup : MonoBehaviour
{

    public PlayerStats itemStat;
    public string ItemName;
    public GameObject textObj;

    void Start()
    {
        if (textObj.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text)){
            text.SetText(ItemName + "\n" + itemStat.ToString());
        }
        else
        {
            Debug.Log(ItemName);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<StatManager>().AddStat(itemStat);
            gameObject.SetActive(false);
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Pickup : MonoBehaviour
{
    public ItemStat itemStat;

    public GameObject nameTextObj;
    public RectTransform descRect;
    public GameObject statHolder;
    public float addedStatOffset;

    void Start()
    {
        SetName();
        SetDescription();
    }


    private void SetName()
    {
        if (nameTextObj.TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text)){
            text.SetText(itemStat.itemName);
        }
        else
        {
            Debug.Log(itemStat.itemName);
        }
    }

    private void SetDescription()
    {
        int count = itemStat.StatCount();
        RectTransform statHolderRect = statHolder.GetComponent<RectTransform>();

        descRect.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Vertical,
            count*Mathf.Abs(addedStatOffset)
        );

        int index = 0;
        foreach ((Stat stat, ItemStat.StatName name) in itemStat.GetActiveStats())
        {
            // desc

            // Criando instancia
            GameObject newStatHolder = Instantiate(statHolder,statHolder.transform.parent);

            //Alterando posição
            Vector2 newPosition = statHolderRect.anchoredPosition;
            newPosition.y += addedStatOffset*index;
            newStatHolder.GetComponent<RectTransform>().anchoredPosition = newPosition;
            
            // Alterando icone
            UnityEngine.UI.Image statImage = newStatHolder.GetComponentInChildren<UnityEngine.UI.Image>();
            statImage.sprite = itemStat.GetStatSpriteFromEnum(name);
            
            // Alterando Descrição
            newStatHolder.GetComponent<TextMeshProUGUI>().SetText(stat.ToString());

            index++;
        }

        statHolder.SetActive(false);

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<StatManager>().AddStat(itemStat.statsModifier);

            //Destroy
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject player;
    public GameObject gameM;
    public GameObject upgradeShop;


    [SerializeField]
    private string itemName;
    [SerializeField]
    private TextMeshPro textItemName;
    [SerializeField]
    private TextMeshProUGUI textItemCost;
    public int cost;
    [SerializeField]
    private int itemNum;
    [SerializeField]
    private string description;
    [SerializeField]
    private Sprite itemSprite;
    [SerializeField]
    private GameObject itemDescription;
    [SerializeField]
    private Tooltip toolTip;



    // Start is called before the first frame update
    void Start()
    {
        textItemName = GetComponentInChildren<TextMeshPro>();
        itemSprite = GetComponentInChildren<SpriteRenderer>().sprite;
        toolTip = GetComponentInChildren<Tooltip>();
        textItemName.text = itemName;
        textItemCost.text = "Cost: " + cost;
        toolTip.manager = gameM.GetComponent<gameManager>();
    }

    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(buy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buy() 
    {
        if (textItemCost.text != "Bought") 
        {
            if (player.GetComponent<PlayerMovement>().bank >= cost) 
            {
                player.GetComponent<PlayerMovement>().bank -= cost;
                textItemCost.text = "Bought";
                gameM.GetComponent<gameManager>().itemCounts[itemNum]++;
                gameM.GetComponent<gameManager>().itemListUpdate();
                GameObject des = Instantiate(itemDescription);
                des.GetComponent<ItemDescription>().itemName = itemName;
                des.GetComponent<ItemDescription>().item = itemSprite;
                des.GetComponent<ItemDescription>().description = description;
                des.GetComponent<Canvas>().worldCamera = Camera.main;
                if (upgradeShop != null) 
                {
                    upgradeShop.GetComponent<upgradeShopWepButtons>().updateInShop();
                }
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}

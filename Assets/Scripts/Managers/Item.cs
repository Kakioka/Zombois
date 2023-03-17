using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject player;
    public GameObject gameM;
    public string itemName;
    public TextMeshProUGUI textItemName;
    public TextMeshProUGUI textItemCost;
    public int cost;
    public int itemNum;
    public string description;
    public Sprite itemSprite;
    public GameObject itemDescription;
    public Camera cam;


    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        itemSprite = GetComponentInChildren<SpriteRenderer>().sprite;
        textItemName.text = itemName;
        textItemCost.text = "Cost: " + cost;
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
                GameObject des = Instantiate(itemDescription);
                des.GetComponent<ItemDescription>().itemName = itemName;
                des.GetComponent<ItemDescription>().item = itemSprite;
                des.GetComponent<ItemDescription>().description = description;
                des.GetComponent<Canvas>().worldCamera = cam;
            }
        }
    }
}

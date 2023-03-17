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

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        textItemName.text = itemName;
        textItemCost.text = "Cost: " + cost;
        parent = this.transform.parent.gameObject;
        parent.GetComponent<ItemDescription>().description = description;
        parent.GetComponent<ItemDescription>().item = itemSprite;
        parent.GetComponent<ItemDescription>().itemName.text = itemName;
        parent.GetComponent<ItemDescription>().box.SetActive(false);
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
                parent.GetComponent<ItemDescription>().box.SetActive(true);
            }
        }
    }
}

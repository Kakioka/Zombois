using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    private GameObject player;
    private GameObject gameM;

    public Transform[] itemPos = new Transform[3];
    public GameObject[] item = new GameObject[3];



    public int refreshCost;
    public TextMeshProUGUI refreshbuttonText;
    public int refreshCount;
    public TextMeshProUGUI refreshText;

    // Start is called before the first frame update
    void Start()
    {
        
        refreshbuttonText.text = "Cost: " + refreshCost;
        refreshText.text = "Refresh shop chances: " + refreshCount;
        player = gameObject.GetComponent<upgradeShopManager>().player;
        gameM = gameObject.GetComponent<upgradeShopManager>().gameManager;

        for (int i = 0; i < item.Length; i++)
        {
            item[i] = Instantiate(Items[Random.Range(0, Items.Count)], itemPos[i]);
            item[i].GetComponent<Item>().player = player;
            item[i].GetComponent<Item>().gameM = gameM;
            item[i].GetComponent<Item>().upgradeShop = gameObject;
        }
    }

    public void refresh() 
    {
        if (player.GetComponent<PlayerMovement>().bank >= refreshCost && refreshCount != 0) 
        {
            for (int i = 0; i < item.Length; i++)
            {
                Destroy(item[i]);
                item[i] = Instantiate(Items[Random.Range(0, Items.Count)], itemPos[i]);
                item[i].GetComponent<Item>().player = player;
                item[i].GetComponent<Item>().gameM = gameM;
                item[i].GetComponent<Item>().upgradeShop = gameObject;
            }
            player.GetComponent<PlayerMovement>().bank -= refreshCost;
            refreshCount--;
            refreshText.text = "Refresh shop chances: " + refreshCount;
            GetComponent<upgradeShopWepButtons>().refreshWep();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

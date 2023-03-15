using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    private GameObject player;
    private GameObject gameM;

    public Transform item1;
    public Transform item2;
    public Transform item3;
    public Transform item4;
    public Transform item5;
    public Transform item6;

    public GameObject item1Obj;
    public GameObject item2Obj;
    public GameObject item3Obj;
    public GameObject item4Obj;
    public GameObject item5Obj;
    public GameObject item6Obj;

    public int refreshCost;
    public TextMeshProUGUI refreshbuttonText;

    // Start is called before the first frame update
    void Start()
    {
        refreshbuttonText.text = "Cost: " + refreshCost;

        player = gameObject.GetComponent<upgradeShopManager>().player;
        gameM = gameObject.GetComponent<upgradeShopManager>().gameManager;

        item1Obj = Instantiate(Items[Random.Range(0, Items.Count)], item1);
        item1Obj.GetComponent<Item>().player = player;
        item1Obj.GetComponent<Item>().gameM = gameM;

        item2Obj = Instantiate(Items[Random.Range(0, Items.Count)], item2);
        item2Obj.GetComponent<Item>().player = player;
        item2Obj.GetComponent<Item>().gameM = gameM;

        item3Obj = Instantiate(Items[Random.Range(0, Items.Count)], item3);
        item3Obj.GetComponent<Item>().player = player;
        item3Obj.GetComponent<Item>().gameM = gameM;

        item4Obj = Instantiate(Items[Random.Range(0, Items.Count)], item4);
        item4Obj.GetComponent<Item>().player = player;
        item4Obj.GetComponent<Item>().gameM = gameM;

        item5Obj = Instantiate(Items[Random.Range(0, Items.Count)], item5);
        item5Obj.GetComponent<Item>().player = player;
        item5Obj.GetComponent<Item>().gameM = gameM;

        item6Obj = Instantiate(Items[Random.Range(0, Items.Count)], item6);
        item6Obj.GetComponent<Item>().player = player;
        item6Obj.GetComponent<Item>().gameM = gameM;
    }

    public void refresh() 
    {
        if (player.GetComponent<PlayerMovement>().bank >= refreshCost) 
        {
            Destroy(item1Obj);
            Destroy(item2Obj);
            Destroy(item3Obj);
            item1Obj = Instantiate(Items[Random.Range(0, Items.Count)], item1);
            item1Obj.GetComponent<Item>().player = player;
            item1Obj.GetComponent<Item>().gameM = gameM;

            item2Obj = Instantiate(Items[Random.Range(0, Items.Count)], item2);
            item2Obj.GetComponent<Item>().player = player;
            item2Obj.GetComponent<Item>().gameM = gameM;

            item3Obj = Instantiate(Items[Random.Range(0, Items.Count)], item3);
            item3Obj.GetComponent<Item>().player = player;
            item3Obj.GetComponent<Item>().gameM = gameM;

            player.GetComponent<PlayerMovement>().bank -= refreshCost;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

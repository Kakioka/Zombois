using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<upgradeShopManager>().player;
        gameM = gameObject.GetComponent<upgradeShopManager>().gameManager;

        GameObject item = Instantiate(Items[Random.Range(0, Items.Count)], item1);
        item.GetComponent<Item>().player = player;
        item.GetComponent<Item>().gameM = gameM;

        item = Instantiate(Items[Random.Range(0, Items.Count)], item2);
        item.GetComponent<Item>().player = player;
        item.GetComponent<Item>().gameM = gameM;

        item = Instantiate(Items[Random.Range(0, Items.Count)], item3);
        item.GetComponent<Item>().player = player;
        item.GetComponent<Item>().gameM = gameM;

        item = Instantiate(Items[Random.Range(0, Items.Count)], item4);
        item.GetComponent<Item>().player = player;
        item.GetComponent<Item>().gameM = gameM;

        item = Instantiate(Items[Random.Range(0, Items.Count)], item5);
        item.GetComponent<Item>().player = player;
        item.GetComponent<Item>().gameM = gameM;

        item = Instantiate(Items[Random.Range(0, Items.Count)], item6);
        item.GetComponent<Item>().player = player;
        item.GetComponent<Item>().gameM = gameM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    private GameObject player;
    private GameObject gameM;

    public Transform[] itemPos = new Transform[6];
    public GameObject[] item = new GameObject[6];



    public int refreshCost;
    public TextMeshProUGUI refreshbuttonText;

    // Start is called before the first frame update
    void Start()
    {
        refreshbuttonText.text = "Cost: " + refreshCost;

        player = gameObject.GetComponent<upgradeShopManager>().player;
        gameM = gameObject.GetComponent<upgradeShopManager>().gameManager;

        for (int i = 0; i < 6; i++)
        {
            item[i] = Instantiate(Items[Random.Range(0, Items.Count)], itemPos[i]);
            item[i].GetComponent<Item>().player = player;
            item[i].GetComponent<Item>().gameM = gameM;
        }
    }

    public void refresh() 
    {
        if (player.GetComponent<PlayerMovement>().bank >= refreshCost) 
        {
            for (int i = 0; i < 6; i++)
            {
                Destroy(item[i]);
                item[i] = Instantiate(Items[Random.Range(0, Items.Count)], itemPos[i]);
                item[i].GetComponent<Item>().player = player;
                item[i].GetComponent<Item>().gameM = gameM;
            }
            player.GetComponent<PlayerMovement>().bank -= refreshCost;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
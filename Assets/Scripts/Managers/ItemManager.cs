using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    public Camera cam;

    private GameObject player;
    private GameObject gameM;

    public Transform[] itemPos = new Transform[6];
    public GameObject[] item = new GameObject[6];



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
        cam = gameM.GetComponent<gameManager>().cam;

        for (int i = 0; i < 6; i++)
        {
            item[i] = Instantiate(Items[Random.Range(0, Items.Count)], itemPos[i]);
            item[i].GetComponent<Item>().player = player;
            item[i].GetComponent<Item>().gameM = gameM;
            item[i].GetComponent<Item>().cam = cam;
        }
    }

    public void refresh() 
    {
        if (player.GetComponent<PlayerMovement>().bank >= refreshCost && refreshCount != 0) 
        {
            for (int i = 0; i < 6; i++)
            {
                Destroy(item[i]);
                item[i] = Instantiate(Items[Random.Range(0, Items.Count)], itemPos[i]);
                item[i].GetComponent<Item>().player = player;
                item[i].GetComponent<Item>().gameM = gameM;
                item[i].GetComponent<Item>().cam = cam;
            }
            player.GetComponent<PlayerMovement>().bank -= refreshCost;
            refreshCount--;
            refreshText.text = "Refresh shop chances: " + refreshCount;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

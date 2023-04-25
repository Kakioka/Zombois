using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpChoice : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> choices = new List<GameObject>();

    [SerializeField]
    private List<GameObject> itemCards = new List<GameObject>();

    private GameObject choice;

    public GameObject gameM;

    [SerializeField]
    private List<GameObject> itemChoices = new List<GameObject>();
    [SerializeField]
    private List<int> itemNums = new List<int>();

    [SerializeField]
    private GameObject skipButton;

    // Start is called before the first frame update

    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        choice = gameObject;
        gameObject.SetActive(false);
        skipButton.SetActive(false);
        /*if (gameM.GetComponent<gameManager>().itemCounts[28] <= 1)
        {
            skipButton.SetActive(false);
        }
        GetComponent<Canvas>().worldCamera = Camera.main;
        Time.timeScale = 0;
        choice = gameObject;
        for (int i = 0; i < 3; i++)
        {
            bool temp = false;
            while (!temp)
            {
                int ran = Random.Range(1, itemCards.Count);
                if (!itemNums.Contains(ran))
                {
                    itemChoices.Add(Instantiate(itemCards[ran], choices[i].transform));
                    itemNums.Add(ran);
                    temp = true;
                }
            }
            if (itemChoices[i].GetComponent<weaponCard>() != null)
            {
                itemChoices[i].GetComponent<weaponCard>().gameM = gameM;
                itemChoices[i].GetComponent<weaponCard>().wepCost = 0;
            }
            else
            {
                itemChoices[i].GetComponent<Item>().gameM = gameM;
                itemChoices[i].GetComponent<Item>().cost = 0;
            }
            itemChoices[i].GetComponentInChildren<Button>().onClick.AddListener(closeLevelUp);
            itemChoices[i].GetComponentInChildren<Button>().onClick.AddListener(wepSet);
            GameObject b = itemChoices[i].GetComponentInChildren<Button>().gameObject;
            b.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
            itemChoices[i].GetComponent<weaponCard>().player = gameM.GetComponent<gameManager>().player;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < 3; i++)
        {
            GameObject b = itemChoices[i].GetComponentInChildren<Button>().gameObject;
            b.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
        }*/
    }

    public void levelUp()
    {
        choice.SetActive(true);
        Time.timeScale = 0;
        if (gameM.GetComponent<gameManager>().itemCounts[28] > 0)
        {
            skipButton.SetActive(true);
            skipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Refresh: " + gameM.GetComponent<gameManager>().itemCounts[28];
        }
        for (int i = 0; i < 3; i++)
        {
            bool temp = false;
            while (!temp)
            {
                int ran = Random.Range(1, itemCards.Count);
                if (!itemNums.Contains(ran))
                {
                    itemChoices[i] = (Instantiate(itemCards[ran], choices[i].transform));
                    itemNums[i] = ran;
                    temp = true;
                }
            }

            if (itemChoices[i].GetComponent<weaponCard>() != null)
            {
                itemChoices[i].GetComponent<weaponCard>().gameM = gameM;
                itemChoices[i].GetComponent<weaponCard>().wepCost = 0;
                itemChoices[i].GetComponent<weaponCard>().player = gameM.GetComponent<gameManager>().player;
            }
            else
            {
                itemChoices[i].GetComponent<Item>().gameM = gameM;
                itemChoices[i].GetComponent<Item>().cost = 0;
                itemChoices[i].GetComponent<Item>().player = gameM.GetComponent<gameManager>().player;
                itemChoices[i].transform.localScale = new Vector3(120, 120, 120);
                itemChoices[i].transform.position = new Vector3(itemChoices[i].transform.position.x, itemChoices[i].transform.position.y, itemChoices[i].transform.position.z + 1f);
            }
            itemChoices[i].GetComponentInChildren<Button>().onClick.AddListener(wepSet);
            itemChoices[i].GetComponentInChildren<Button>().onClick.AddListener(closeLevelUp);
            GameObject b = itemChoices[i].GetComponentInChildren<Button>().gameObject;
            b.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
            //for (int j = 0; j < 3; j++)
            //{
                //GameObject g = itemChoices[i].GetComponentInChildren<Button>().gameObject;
                //g.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
            //}
        }
    }

    public void closeLevelUp()
    {
        Time.timeScale = 1;
        for(int i = 0; i < itemChoices.Count; i++)
        {
            Destroy(itemChoices[i]);
        }
        choice.SetActive(false);
    }

    public void Refresh()
    {
        for (int i = 0; i < itemChoices.Count; i++)
        {
            Destroy(itemChoices[i]);
        }
        if (gameM.GetComponent<gameManager>().itemCounts[28] > 0)
        {
            skipButton.SetActive(true);
            skipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Refresh: " + gameM.GetComponent<gameManager>().itemCounts[28];
        }
        for (int i = 0; i < 3; i++)
        {
            bool temp = false;
            while (!temp)
            {
                int ran = Random.Range(1, itemCards.Count);
                if (!itemNums.Contains(ran))
                {
                    itemChoices[i] = (Instantiate(itemCards[ran], choices[i].transform));
                    itemNums[i] = ran;
                    temp = true;
                }
            }

            if (itemChoices[i].GetComponent<weaponCard>() != null)
            {
                itemChoices[i].GetComponent<weaponCard>().gameM = gameM;
                itemChoices[i].GetComponent<weaponCard>().wepCost = 0;
                itemChoices[i].GetComponent<weaponCard>().player = gameM.GetComponent<gameManager>().player;
            }
            else
            {
                itemChoices[i].GetComponent<Item>().gameM = gameM;
                itemChoices[i].GetComponent<Item>().cost = 0;
                itemChoices[i].GetComponent<Item>().player = gameM.GetComponent<gameManager>().player;
                itemChoices[i].transform.localScale = new Vector3(120, 120, 120);
                itemChoices[i].transform.position = new Vector3(itemChoices[i].transform.position.x, itemChoices[i].transform.position.y, itemChoices[i].transform.position.z + 1f);
            }
            itemChoices[i].GetComponentInChildren<Button>().onClick.AddListener(wepSet);
            itemChoices[i].GetComponentInChildren<Button>().onClick.AddListener(closeLevelUp);
            GameObject b = itemChoices[i].GetComponentInChildren<Button>().gameObject;
            b.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
            //for (int j = 0; j < 3; j++)
            //{
            //GameObject g = itemChoices[i].GetComponentInChildren<Button>().gameObject;
            //g.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
            //}
        }
    }

    public void wepSet()
    {
        Destroy(gameM.GetComponent<gameManager>().gun);
        gameM.GetComponent<gameManager>().spawnWep(gameM.GetComponent<gameManager>().wepNum);
        gameM.GetComponent<gameManager>().itemUpgradeGun(gameM.GetComponent<gameManager>().gun, gameM.GetComponent<gameManager>().guns[gameM.GetComponent<gameManager>().wepNum]);
        gameM.GetComponent<gameManager>().itemUpgradePlayer();
    }
}

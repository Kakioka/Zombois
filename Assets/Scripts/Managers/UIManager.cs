using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject arrow;

    public TextMeshProUGUI ammo;
    public TextMeshProUGUI cash;

    public GameObject player;
    public GameObject sister;
    public GameObject gun;

    public GameObject reload;

    public SpriteRenderer h3;
    public SpriteRenderer h2;
    public SpriteRenderer h1;

    public SpriteRenderer sh3;
    public SpriteRenderer sh2;
    public SpriteRenderer sh1;

    public Animator aniGun;

    public GameObject sisH;

    //item UI
    public Transform itemPos;
    public float itemBuffer;
    public List<GameObject> items = new List<GameObject>();
    private List<GameObject> currItems = new List<GameObject>();
    private List<int> currItemIndex = new List<int>();
    private Vector3 lastItemPos;

    [SerializeField]
    private Sprite armor;
    [SerializeField]
    private Sprite heart;

    // Start is called before the first frame update
    void Start()
    {
        lastItemPos = itemPos.position;
        h1.color = Color.white;
        h2.color = Color.white;
        h3.color = Color.white;
        //aniGun.speed /= gun.GetComponent<Gun>().reloadSpeed;
        spawnItemList();
    }

    // Update is called once per frame
    void Update()
    {
        cash.text = "Cash: " + player.GetComponent<PlayerMovement>().bank.ToString();
        ammo.text = gun.GetComponent<Gun>().ammo.ToString() + "/" + gun.GetComponent<Gun>().maxAmmo.ToString();

        if (gameManager.GetComponent<gameManager>().currManager.GetComponent<stageManager>() != null)
        {
            if (!sister.GetComponent<SpriteRenderer>().isVisible && !gameManager.GetComponent<gameManager>().currManager.GetComponent<stageManager>().bossSpawned)
            {
                arrow.SetActive(true);
            }
            else
            {
                arrow.SetActive(false);
            }
        }
        else 
        {
            arrow.SetActive(false);
        }

        switch (player.GetComponent<PlayerMovement>().armor) 
        {
            case 0:
                h1.GetComponent<SpriteRenderer>().sprite = heart;
                h2.GetComponent<SpriteRenderer>().sprite = heart;
                h3.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 1:
                h1.GetComponent<SpriteRenderer>().sprite = armor;
                h2.GetComponent<SpriteRenderer>().sprite = heart;
                h3.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 2:
                h1.GetComponent<SpriteRenderer>().sprite = armor;
                h2.GetComponent<SpriteRenderer>().sprite = armor;
                h3.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 3:
                h1.GetComponent<SpriteRenderer>().sprite = armor;
                h2.GetComponent<SpriteRenderer>().sprite = armor;
                h3.GetComponent<SpriteRenderer>().sprite = armor;
                break;
        }


        switch (sister.GetComponent<Sister>().armor)
        {
            case 0:
                sh1.GetComponent<SpriteRenderer>().sprite = heart;
                sh2.GetComponent<SpriteRenderer>().sprite = heart;
                sh3.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 1:
                sh1.GetComponent<SpriteRenderer>().sprite = armor;
                sh2.GetComponent<SpriteRenderer>().sprite = heart;
                sh3.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 2:
                sh1.GetComponent<SpriteRenderer>().sprite = armor;
                sh2.GetComponent<SpriteRenderer>().sprite = armor;
                sh3.GetComponent<SpriteRenderer>().sprite = heart;
                break;
            case 3:
                sh1.GetComponent<SpriteRenderer>().sprite = armor;
                sh2.GetComponent<SpriteRenderer>().sprite = armor;
                sh3.GetComponent<SpriteRenderer>().sprite = armor;
                break;
        }

        switch (player.GetComponent<PlayerMovement>().health)
        {
            case 0:
                h1.color = Color.black;
                h2.color = Color.black;
                h3.color = Color.black;
                break;
            case 1:
                h1.color = Color.white;
                h2.color = Color.black;
                h3.color = Color.black;
                break;
            case 2:
                h3.color = Color.black;
                h1.color = Color.white;
                h2.color = Color.white;
                break;
            case 3:
                h1.color = Color.white;
                h2.color = Color.white;
                h3.color = Color.white;
                break;
        }

        switch (sister.GetComponent<Sister>().health)
        {
            case 0:
                sh1.color = Color.black;
                sh2.color = Color.black;
                sh3.color = Color.black;
                break;
            case 1:
                sh1.color = Color.white;
                if (sister.GetComponent<Sister>().armor >= 2)
                {
                    sh2.color = Color.black;
                }
                else 
                {
                    sh2.color = Color.white;
                }
                if (sister.GetComponent<Sister>().armor != 3)
                {
                    sh3.color = Color.black;
                }
                else 
                {
                    sh3.color = Color.white;
                }
                break;
            case 2:
                if (sister.GetComponent<Sister>().armor != 3)
                {
                    sh3.color = Color.black;
                }
                else
                {
                    sh3.color = Color.white;
                }
                sh1.color = Color.white;
                sh2.color = Color.white;
                break;
            case 3:
                sh1.color = Color.white;
                sh2.color = Color.white;
                sh3.color = Color.white;
                break;
        }

        switch (sister.GetComponent<Sister>().maxHealth) 
        {
            case 0:
                sh1.enabled = false;
                sh2.enabled = false;
                sh3.enabled = false;
                break;
            case 1:
                sh2.enabled = false;
                sh3.enabled = false;
                break;
            case 2:
                sh3.enabled = false;
                break;
        }


        aniGun.SetBool("ReloadTrigger", gun.GetComponent<Gun>().isReload);
    }

    public void updateItemList() 
    {
        for(int i = 0; i < gameManager.GetComponent<gameManager>().itemEquiped.Count; i++) 
        {
            if (!currItemIndex.Contains(gameManager.GetComponent<gameManager>().itemEquiped[i]))
            {
                GameObject temp = Instantiate(items[gameManager.GetComponent<gameManager>().itemEquiped[i]], itemPos);
                temp.transform.position = lastItemPos;
                currItems.Add(temp);
                temp.GetComponentInChildren<TextMeshPro>().text = gameManager.GetComponent<gameManager>().itemCounts[gameManager.GetComponent<gameManager>().itemEquiped[i]].ToString();
                currItemIndex.Add(gameManager.GetComponent<gameManager>().itemEquiped[i]);
                lastItemPos.x +=  itemBuffer;
                if (currItemIndex.Count % 10 == 0) 
                {
                    lastItemPos.x = itemPos.position.x;
                    lastItemPos.y -= itemBuffer;
                }
            }
            else 
            {
                currItems[i].GetComponentInChildren<TextMeshPro>().text = gameManager.GetComponent<gameManager>().itemCounts[gameManager.GetComponent<gameManager>().itemEquiped[i]].ToString();
            }
        }
    }

    public void spawnItemList()
    {
        for (int i = 0; i < gameManager.GetComponent<gameManager>().itemEquiped.Count; i++)
        {    
            GameObject temp = Instantiate(items[gameManager.GetComponent<gameManager>().itemEquiped[i]], itemPos);
            //lastItemPos.z = 0;
            temp.transform.position = lastItemPos;
            currItems.Add(temp);
            temp.GetComponentInChildren<TextMeshPro>().text = gameManager.GetComponent<gameManager>().itemCounts[gameManager.GetComponent<gameManager>().itemEquiped[i]].ToString();
            temp.GetComponentInChildren<Tooltip>().manager = gameManager.GetComponent<gameManager>();
            currItemIndex.Add(gameManager.GetComponent<gameManager>().itemEquiped[i]);
            lastItemPos.x += itemBuffer;
            if (currItemIndex.Count % 10 == 0)
            {
                lastItemPos.x = itemPos.position.x;
                lastItemPos.y -= itemBuffer;
            }
        }
    }
}

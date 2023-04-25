using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChoice : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> choices = new List<GameObject>();

    [SerializeField]
    private List<GameObject> wepCards = new List<GameObject>();

    private GameObject choice;

    public GameObject gameM;

    private List<GameObject> wepChoices = new List<GameObject>();
    private List<int> wepNums = new List<int>();

    // Start is called before the first frame update

    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        Time.timeScale = 0;
        choice = gameObject;
        for (int i = 0; i < 3; i++)
        {
            bool temp = false;
            while (!temp)
            {
                int ran = Random.Range(1, wepCards.Count);
                if (!wepNums.Contains(ran))
                {
                    wepChoices.Add(Instantiate(wepCards[ran], choices[i].transform));
                    wepNums.Add(ran);
                    temp = true;
                }
            }
            wepChoices[i].GetComponent<weaponCard>().gameM = gameM;
            wepChoices[i].GetComponent<weaponCard>().wepCost = 0;
            wepChoices[i].GetComponentInChildren<Button>().onClick.AddListener(skip);
            wepChoices[i].GetComponentInChildren<Button>().onClick.AddListener(wepSet);
            GameObject b = wepChoices[i].GetComponentInChildren<Button>().gameObject;
            b.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
            wepChoices[i].GetComponent<weaponCard>().player = gameM.GetComponent<gameManager>().player;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
                GameObject b = wepChoices[i].GetComponentInChildren<Button>().gameObject;
                b.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
            }
        }

        public void skip()
        {
            Time.timeScale = 1;
            Destroy(choice);
        }


        
    
    public void wepSet() 
    {
        Destroy(gameM.GetComponent<gameManager>().gun);
        gameM.GetComponent<gameManager>().spawnWep(gameM.GetComponent<gameManager>().wepNum);
        gameM.GetComponent<gameManager>().itemUpgradeGun(gameM.GetComponent<gameManager>().gun, gameM.GetComponent<gameManager>().guns[gameM.GetComponent<gameManager>().wepNum]);
    }
} 


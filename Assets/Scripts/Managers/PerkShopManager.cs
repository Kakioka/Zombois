using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PerkShopManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> perkButtons = new List<GameObject>();

    [SerializeField]
    private GameObject perkM;

    [SerializeField]
    private TextMeshProUGUI coinCounter;

    [SerializeField]
    private List<int> perkCosts = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        perkM = GameObject.FindGameObjectWithTag("GameController");
        setButtons();
        coinCounter.text = "Moon Coins: " + perkM.GetComponent<PerkManager>().moonCoin;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setButtons()
    {
        for (int i = 0; i < perkButtons.Count; i++)
        {
            if (perkM.GetComponent<PerkManager>().perkOwned[i])
            {
                if (perkM.GetComponent<PerkManager>().perkEquiped[i])
                {
                    perkButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Equipped";
                }
                else
                {
                    perkButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
                }
                
            }
            else
            {
                perkButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + perkCosts[i];
            }
        }
    }

    public void perkButton(int i)
    {
        if (!perkM.GetComponent<PerkManager>().perkOwned[i])
        {
            if (perkM.GetComponent<PerkManager>().moonCoin > perkCosts[i])
            {
                perkM.GetComponent<PerkManager>().moonCoin -= perkCosts[i];
                perkM.GetComponent<PerkManager>().perkOwned[i] = true;
                for (int b = 0;  b < perkM.GetComponent<PerkManager>().perkEquiped.Count; b++)
                {
                    perkM.GetComponent<PerkManager>().perkEquiped[b] = false;
                }
                perkM.GetComponent<PerkManager>().perkEquiped[i] = true;
                setButtons();
                coinCounter.text = "Moon Coins: " + perkM.GetComponent<PerkManager>().moonCoin;

            }
        }
        else
        {
            for (int b = 0; b < perkM.GetComponent<PerkManager>().perkEquiped.Count; b++)
            {
                perkM.GetComponent<PerkManager>().perkEquiped[b] = false;
            }
            perkM.GetComponent<PerkManager>().perkEquiped[i] = true;
            setButtons();
        }
    }
}

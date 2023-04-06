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

    // Start is called before the first frame update
    void Start()
    {
        perkM = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        setButtons();
    }

    void setButtons()
    {
        for (int i = 0; i < perkButtons.Count; i++)
        {
            if (perkM.GetComponent<PerkManager>().perkOwned[i])
            {
                perkButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
            }
            else
            {
                perkButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = "Cost: 2";
            }
        }
    }

    public void perkButtonDamage()
    {
        if (!perkM.GetComponent<PerkManager>().perkOwned[0])
        {
            if(perkM.GetComponent<PerkManager>().moonCoin > )
        }
        else
        {
            perkM.GetComponent<PerkManager>().perkEquiped[0] = true;
            perkM.GetComponent<PerkManager>().perkEquiped[1] = false;
            perkM.GetComponent<PerkManager>().perkEquiped[2] = false;
            perkM.GetComponent<PerkManager>().perkEquiped[3] = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class weaponCard : MonoBehaviour
{
    public GameObject player;
    public GameObject gameM;
    public TextMeshProUGUI buttonText;
    public upgradeShopWepButtons upgradeShopWepButtons;
    public int wepNum;
    public int wepCost;
    public Tooltip toolTip;

    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = "Cost: " + wepCost;
        toolTip.manager = gameM.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameM.GetComponent<gameManager>().wepNum == wepNum)
        {
            buttonText.text = "Bought";
        }
    }

    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(wepButton);
    }

    private void OnMouseOver()
    {
        toolTip.ShowTooltip();
    }

    private void OnMouseExit()
    {
        toolTip.HideTooltip();
    }

    public void wepButton()
    {
        if (gameM.GetComponent<gameManager>().wepNum != wepNum)
        {
            if (player.GetComponent<PlayerMovement>().bank >= wepCost)
            {
                buttonText.text = "Bought";
                player.GetComponent<PlayerMovement>().bank -= wepCost;
                gameM.GetComponent<gameManager>().wepNum = wepNum;
                if (upgradeShopWepButtons != null) 
                {
                    upgradeShopWepButtons.setWeapon();
                }
            }
        }
    }
 }

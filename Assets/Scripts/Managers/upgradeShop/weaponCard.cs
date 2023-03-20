using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weaponCard : MonoBehaviour
{
    public GameObject player;
    public GameObject gameM;
    public TextMeshProUGUI buttonText;
    public upgradeShopWepButtons upgradeShopWepButtons;
    public int wepNum;
    public int wepCost;

    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = "Cost: " + wepCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameM.GetComponent<gameManager>().wepNum == wepNum)
        {
            buttonText.text = "Bought";
        }    
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
                upgradeShopWepButtons.setWeapon();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class upgradeShopManager : MonoBehaviour
{
    public GameObject gameManager;
    public TextMeshProUGUI shotgun;
    public TextMeshProUGUI revolver;
    public TextMeshProUGUI machineGun;
    public TextMeshProUGUI sniper;
    public TextMeshProUGUI bankText;

    public int shotgunPrice;
    public int sniperPrice;
    public int machineGunPrice;

    public int bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = gameManager.GetComponent<gameManager>().bank;
    }

    // Update is called once per frame
    void Update()
    {

        bankText.text = bank.ToString();
        wepButtons();
    }

    void wepButtons()
    {
        if (gameManager.GetComponent<gameManager>().revO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 1)
            {
                revolver.text = "Equipped";
            }
            else
            {
                revolver.text = "Equip";
            }
        }
        else
        {
            revolver.text = "Buy";
        }

        if (gameManager.GetComponent<gameManager>().shotgunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 2)
            {
                shotgun.text = "Equipped";
            }
            else
            {
                shotgun.text = "Equip";
            }
        }
        else
        {
            shotgun.text = "Buy";
        }

        if (gameManager.GetComponent<gameManager>().machinegunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 3)
            {
                machineGun.text = "Equipped";
            }
            else
            {
                machineGun.text = "Equip";
            }
        }
        else
        {
            machineGun.text = "Buy";
        }

        if (gameManager.GetComponent<gameManager>().sniperO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 4)
            {
                sniper.text = "Equipped";
            }
            else
            {
                sniper.text = "Equip";
            }
        }
        else
        {
            sniper.text = "Buy";
        }
    }

    public void shotgunButton()
    {
        if (gameManager.GetComponent<gameManager>().shotgunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum != 2)
            {
                gameManager.GetComponent<gameManager>().wepNum = 2;
            }
        }
        else
        {
            if (bank >= shotgunPrice)
            {
                bank -= shotgunPrice;
                gameManager.GetComponent<gameManager>().shotgunO = true;
            }
        }
    }

    public void machineGunButton()
    {
        if (gameManager.GetComponent<gameManager>().machinegunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum != 3)
            {
                gameManager.GetComponent<gameManager>().wepNum = 3;
            }
        }
        else
        {
            if (bank >= machineGunPrice)
            {
                bank -= machineGunPrice;
                gameManager.GetComponent<gameManager>().machinegunO = true;
            }
        }
    }

    public void sniperButton()
    {
        if (gameManager.GetComponent<gameManager>().sniperO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum != 4)
            {
                gameManager.GetComponent<gameManager>().wepNum = 4;
            }
        }
        else
        {
            if (bank >= sniperPrice)
            {
                bank -= sniperPrice;
                gameManager.GetComponent<gameManager>().sniperO = true;
            }
        }
    }

    public void revolverButton()
    {
        if (gameManager.GetComponent<gameManager>().revO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum != 1)
            {
                gameManager.GetComponent<gameManager>().wepNum = 1;
            }
        }
    }

    public void nextButton()
    {
        gameManager.GetComponent<gameManager>().bank = bank;
        gameManager.GetComponent<gameManager>().spawnLevel(1);
    }
}

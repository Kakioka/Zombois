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

    public TextMeshProUGUI damage;
    public TextMeshProUGUI fireRate;
    public TextMeshProUGUI reload;
    public TextMeshProUGUI knockBack;
    public TextMeshProUGUI bullet;
    public TextMeshProUGUI pierce;
    public TextMeshProUGUI size;
    public TextMeshProUGUI speed;

    public GameObject damageB;
    public GameObject fireRateB;
    public GameObject reloadB;
    public GameObject knockBackB;
    public GameObject bulletB;
    public GameObject pierceB;
    public GameObject sizeB;
    public GameObject speedB;

    public int damageI;
    public int damageII;
    public int damageIII;

    public int fireRateI;
    public int fireRateII;
    public int fireRateIII;

    public int knockBackI;
    public int knockBackII;
    public int knockBackIII;

    public int reloadI;
    public int reloadII;
    public int reloadIII;

    public int bulletI;
    public int bulletII;
    public int bulletIII;

    public int pierceI;
    public int pierceII;
    public int pierceIII;

    public int sizeI;
    public int sizeII;
    public int sizeIII;

    public int speedI;
    public int speedII;
    public int speedIII;

    public GameObject sisHPButton;
    public TextMeshProUGUI sisHPVal;

    public TextMeshProUGUI playerHPVal;
    public GameObject playerHPButton;

    public int vaccineCost;
    public TextMeshProUGUI vaccineCostText;

    public int bank;

    public int pickUpI;
    public int pickUpII;
    public int pickUpIII;

    public int moveSpeedI;
    public int moveSpeedII;
    public int moveSpeedIII;

    public TextMeshProUGUI pickUpText;
    public TextMeshProUGUI moveSpeedText;

    public GameObject pickUpButton;
    public GameObject moveSpeedButton;

    // Start is called before the first frame update
    void Start()
    {
        vaccineCostText.text = vaccineCost.ToString();
        bank = gameManager.GetComponent<gameManager>().bank;
    }

    // Update is called once per frame
    void Update()
    {
        bankText.text = bank.ToString();
        wepButtons();
        wepUpgrades();
        hpVal();
        playerText();
    }

    public void rangeButton() 
    {
        switch (gameManager.GetComponent<gameManager>().rangeUp)
        {
            case 0:
                if (bank >= pickUpI)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 1;
                    bank -= pickUpI;
                }
                break;
            case 1:
                if (bank >= pickUpII)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 2;
                    bank -= pickUpII;
                }
                break;
            case 2:
                if (bank >= pickUpIII)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 3;
                    bank -= pickUpIII;
                }
                break;
        }
    }

    public void playerSpeedButton() 
    {
        switch (gameManager.GetComponent<gameManager>().moveUp)
        {
            case 0:
                if (bank >= moveSpeedI)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 1;
                    bank -= moveSpeedI;
                }
                break;
            case 1:
                if (bank >= moveSpeedII)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 2;
                    bank -= moveSpeedII;
                }
                break;
            case 2:
                if (bank >= moveSpeedIII)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 3;
                    bank -= moveSpeedIII;
                }
                break;
        }
    }

    void playerText() 
    {
        switch (gameManager.GetComponent<gameManager>().moveUp) 
        {
            case 0:
                moveSpeedText.text = "Move Speed Level I";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedI;
                break;
            case 1:
                moveSpeedText.text = "Move Speed Level II";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedII;
                break;
            case 2:
                moveSpeedText.text = "Move Speed Level III";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedIII;
                break;
            case 3:
                moveSpeedText.text = "Move Speed Level Maxed";
                moveSpeedButton.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().rangeUp)
        {
            case 0:
                pickUpText.text = "Pick Up Range Level I";
                pickUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pickUpI;
                break;
            case 1:
                pickUpText.text = "Pick Up Range Level II";
                pickUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pickUpII;
                break;
            case 2:
                pickUpText.text = "Pick Up Range Level III";
                pickUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pickUpIII;
                break;
            case 3:
                pickUpText.text = "Pick Up Range Maxed";
                pickUpButton.SetActive(false);
                break;
        }
    }

    public void sisButton() 
    {
        if (gameManager.GetComponent<gameManager>().sisH != 3) 
        {
            if (bank >= vaccineCost) 
            {
                bank -= vaccineCost;
                gameManager.GetComponent<gameManager>().sisH++;
            }
        }
    }

    public void playerButton()
    {
        if (gameManager.GetComponent<gameManager>().playerH != 3)
        {
            if (bank >= vaccineCost)
            {
                bank -= vaccineCost;
                gameManager.GetComponent<gameManager>().playerH++;
            }
        }
    }

    void hpVal() 
    {
        playerHPVal.text = gameManager.GetComponent<gameManager>().playerH.ToString();
        sisHPVal.text = gameManager.GetComponent<gameManager>().sisH.ToString();

        if (gameManager.GetComponent<gameManager>().playerH == 3)
        {
            playerHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "HP Max";
        }
        else 
        {
            playerHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }

        if (gameManager.GetComponent<gameManager>().sisH == 3)
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "HP Max";
        }
        else 
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }
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
            revolver.text = "Cost: " + shotgunPrice;
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
            shotgun.text = "Cost: " + shotgunPrice;
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
            machineGun.text = "Cost: " + machineGunPrice;
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
            sniper.text = "Cost: " + sniperPrice;
        }
    }

    void wepUpgrades() 
    {
        switch (gameManager.GetComponent<gameManager>().damageUp) 
        {
            case 0:
                damage.text = "Damage Up Level I";
                damageB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + damageI;
                break;
            case 1:
                damage.text = "Damage Up Level II";
                damageB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + damageII;
                break;
            case 2:
                damage.text = "Damage Up Level III";
                damageB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + damageIII;
                break;
            case 3:
                damage.text = "Damage Up Maxed";
                damageB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().fireUp)
        {
            case 0:
                fireRate.text = "Fire Rate Up Level I";
                fireRateB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + fireRateI;
                break;
            case 1:
                fireRate.text = "Fire Rate Up Level II";
                fireRateB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + fireRateII;
                break;
            case 2:
                fireRate.text = "Fire Rate Up Level III";
                fireRateB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + fireRateIII;
                break;
            case 3:
                fireRate.text = "Fire Rate Up Maxed";
                fireRateB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().reloadUp)
        {
            case 0:
                reload.text = "Reload Speed Up Level I";
                reloadB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + reloadI;
                break;
            case 1:
                reload.text = "Reload Speed Up Level II";
                reloadB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + reloadII;
                break;
            case 2:
                reload.text = "Reload Speed Up Level III";
                reloadB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + reloadIII;
                break;
            case 3:
                reload.text = "Reload Speed Up Maxed";
                reloadB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().knockUp)
        {
            case 0:
                knockBack.text = "Knock Back Up Level I";
                knockBackB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + knockBackI;
                break;
            case 1:
                knockBack.text = "Knock Back Up Level II";
                knockBackB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + knockBackII;
                break;
            case 2:
                knockBack.text = "Knock Back Up Level III";
                knockBackB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + knockBackIII;
                break;
            case 3:
                knockBack.text = "knockBack Up Maxed";
                knockBackB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().speedUp)
        {
            case 0:
                speed.text = "Bullet Speed Up Level I";
                speedB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + speedI;
                break;
            case 1:
                speed.text = "Bullet Speed Up Level II";
                speedB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + speedII;
                break;
            case 2:
                speed.text = "Bullet Speed Up Level III";
                speedB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + speedIII;
                break;
            case 3:
                speed.text = "Bullet Speed Up Maxed";
                speedB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().projectileUp)
        {
            case 0:
                bullet.text = "Bullet Up Level I";
                bulletB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + bulletI;
                break;
            case 1:
                bullet.text = "Bullet Up Level II";
                bulletB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + bulletII;
                break;
            case 2:
                bullet.text = "Bullet Up Level III";
                bulletB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + bulletIII;
                break;
            case 3:
                bullet.text = "Bullet Up Maxed";
                bulletB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().pierceUp)
        {
            case 0:
                pierce.text = "Pierce Up Level I";
                pierceB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pierceI;
                break;
            case 1:
                pierce.text = "Pierce Up Level II";
                pierceB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pierceII;
                break;
            case 2:
                pierce.text = "Pierce Up Level III";
                pierceB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pierceIII;
                break;
            case 3:
                pierce.text = "Pierce Up Maxed";
                pierceB.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().sizeUp)
        {
            case 0:
                size.text = "Size Up Level I";
                sizeB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost :" + sizeI;
                break;
            case 1:
                size.text = "Size Up Level II";
                sizeB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost :" + sizeII;
                break;
            case 2:
                size.text = "Size Up Level III";
                sizeB.GetComponentInChildren<TextMeshProUGUI>().text = "Cost :" + sizeIII;
                break;
            case 3:
                size.text = "Size Up Maxed";
                sizeB.SetActive(false);
                break;
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

    public void damageButton() 
    {
        switch (gameManager.GetComponent<gameManager>().damageUp)
        {
            case 0:
                if(bank >= damageI) 
                {
                    gameManager.GetComponent<gameManager>().damageUp = 1;
                    bank -= damageI;
                }
                break;
            case 1:
                if (bank >= damageII)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 2;
                    bank -= damageII;
                }
                break;
            case 2:
                if (bank >= damageIII)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 3;
                    bank -= damageIII;
                }
                break;
        }
    }

    public void fireRateButton() 
    {
        switch (gameManager.GetComponent<gameManager>().fireUp)
        {
            case 0:
                if(bank >= fireRateI) 
                {
                    gameManager.GetComponent<gameManager>().fireUp = 1;
                    bank -= fireRateI;
                }
                break;
            case 1:
                if (bank >= fireRateII)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 2;
                    bank -= fireRateII;
                }
                break;
            case 2:
                if (bank >= fireRateIII)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 3;
                    bank -= fireRateIII;
                }
                break;
        }
    }

    public void reloadButton() 
    {
        switch (gameManager.GetComponent<gameManager>().reloadUp)
        {
            case 0:
                if (bank >= reloadI)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 1;
                    bank -= reloadI;
                }
                break;
            case 1:
                if (bank >= reloadII)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 2;
                    bank -= reloadII;
                }
                break;
            case 2:
                if (bank >= reloadIII)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 3;
                    bank -= reloadIII;
                }
                break;
        }
    }

    public void knockBackButton() 
    {
        switch (gameManager.GetComponent<gameManager>().knockUp)
        {
            case 0:
                if (bank >= knockBackI)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 1;
                    bank -= knockBackI;
                }
                break;
            case 1:
                if (bank >= knockBackII)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 2;
                    bank -= knockBackII;
                }
                break;
            case 2:
                if (bank >= knockBackIII)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 3;
                    bank -= knockBackIII;
                }
                break;
        }
    }

    public void speedButton() 
    {
        switch (gameManager.GetComponent<gameManager>().speedUp)
        {
            case 0:
                if (bank >= speedI)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 1;
                    bank -= speedI;
                }
                break;
            case 1:
                if (bank >= speedII)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 2;
                    bank -= speedII;
                }
                break;
            case 2:
                if (bank >= speedIII)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 3;
                    bank -= speedIII;
                }
                break;
        }
    }

    public void bulletButton() 
    {
        switch (gameManager.GetComponent<gameManager>().projectileUp)
        {
            case 0:
                if (bank >= bulletI)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 1;
                    bank -= bulletI;
                }
                break;
            case 1:
                if (bank >= bulletII)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 2;
                    bank -= bulletII;
                }
                break;
            case 2:
                if (bank >= bulletIII)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 3;
                    bank -= bulletIII;
                }
                break;
        }
    }

    public void pierceButton() 
    {
        switch (gameManager.GetComponent<gameManager>().pierceUp)
        {
            case 0:
                if (bank >= pierceI)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 1;
                    bank -= pierceI;
                }
                break;
            case 1:
                if (bank >= pierceII)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 2;
                    bank -= pierceII;
                }
                break;
            case 2:
                if (bank >= pierceIII)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 3;
                    bank -= pierceIII;
                }
                break;
        }
    }

    public void sizeButton() 
    {
        switch (gameManager.GetComponent<gameManager>().sizeUp)
        {
            case 0:
                if (bank >= sizeI)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 1;
                    bank -= sizeI;
                }
                break;
            case 1:
                if (bank >= sizeII)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 2;
                    bank -= sizeII;
                }
                break;
            case 2:
                if (bank >= sizeIII)
                {
                    gameManager.GetComponent<gameManager>().sizeUp= 3;
                    bank -= sizeIII;
                }
                break;
        }
    }

    public void nextButton()
    {
        gameManager.GetComponent<gameManager>().bank = bank;
        gameManager.GetComponent<gameManager>().spawnLevel(gameManager.GetComponent<gameManager>().levelNum);
    }
}

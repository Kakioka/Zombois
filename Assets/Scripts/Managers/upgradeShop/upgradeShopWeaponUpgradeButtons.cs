using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class upgradeShopWeaponUpgradeButtons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;

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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<upgradeShopManager>().gameManager;
        player = gameObject.GetComponent<upgradeShopManager>().player;
    }

    // Update is called once per frame
    void Update()
    {
        wepUpgrades();
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

    public void damageButton()
    {
        switch (gameManager.GetComponent<gameManager>().damageUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= damageI)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= damageI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= damageII)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= damageII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= damageIII)
                {
                    gameManager.GetComponent<gameManager>().damageUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= damageIII;
                }
                break;
        }
    }

    public void fireRateButton()
    {
        switch (gameManager.GetComponent<gameManager>().fireUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= fireRateI)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= fireRateI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= fireRateII)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= fireRateII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= fireRateIII)
                {
                    gameManager.GetComponent<gameManager>().fireUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= fireRateIII;
                }
                break;
        }
    }

    public void reloadButton()
    {
        switch (gameManager.GetComponent<gameManager>().reloadUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= reloadI)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= reloadI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= reloadII)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= reloadII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= reloadIII)
                {
                    gameManager.GetComponent<gameManager>().reloadUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= reloadIII;
                }
                break;
        }
    }

    public void knockBackButton()
    {
        switch (gameManager.GetComponent<gameManager>().knockUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= knockBackI)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= knockBackI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= knockBackII)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= knockBackII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= knockBackIII)
                {
                    gameManager.GetComponent<gameManager>().knockUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= knockBackIII;
                }
                break;
        }
    }

    public void speedButton()
    {
        switch (gameManager.GetComponent<gameManager>().speedUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= speedI)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= speedI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= speedII)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= speedII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= speedIII)
                {
                    gameManager.GetComponent<gameManager>().speedUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= speedIII;
                }
                break;
        }
    }

    public void bulletButton()
    {
        switch (gameManager.GetComponent<gameManager>().projectileUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= bulletI)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= bulletI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= bulletII)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= bulletII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= bulletIII)
                {
                    gameManager.GetComponent<gameManager>().projectileUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= bulletIII;
                }
                break;
        }
    }

    public void pierceButton()
    {
        switch (gameManager.GetComponent<gameManager>().pierceUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= pierceI)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= pierceI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= pierceII)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= pierceII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= pierceIII)
                {
                    gameManager.GetComponent<gameManager>().pierceUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= pierceIII;
                }
                break;
        }
    }

    public void sizeButton()
    {
        switch (gameManager.GetComponent<gameManager>().sizeUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= sizeI)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= sizeI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= sizeII)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= sizeII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= sizeIII)
                {
                    gameManager.GetComponent<gameManager>().sizeUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= sizeIII;
                }
                break;
        }
    }
}

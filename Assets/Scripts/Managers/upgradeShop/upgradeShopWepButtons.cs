using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class upgradeShopWepButtons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    public GameObject UI;

    public GameObject revolver;
    public GameObject shotgun;
    public GameObject machineGun;
    public GameObject sniper;

    public GameObject revolverB;
    public GameObject shotgunB;
    public GameObject machineGunB;
    public GameObject sniperB;
    public int shotgunPrice;
    public int sniperPrice;
    public int machineGunPrice;
    public TextMeshProUGUI shotgunT;
    public TextMeshProUGUI revolverT;
    public TextMeshProUGUI machineGunT;
    public TextMeshProUGUI sniperT;
    public int cashTrack;

    public List<GameObject> wepsB = new List<GameObject>();
    public List<GameObject> weps = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    { 
        player = GetComponent<upgradeShopManager>().player;
        gameManager = GetComponent<upgradeShopManager>().gameManager;
        UI = GetComponent<upgradeShopManager>().UI;
        cashTrack = player.GetComponent<PlayerMovement>().bank;

        wepsB.Add(revolverB);
        wepsB.Add(machineGunB);
        wepsB.Add(sniperB);  
        wepsB.Add(sniper);

        weps.Add(revolverB);
        weps.Add(machineGunB);
        weps.Add(sniperB);
        weps.Add(sniper);
    }
    

    // Update is called once per frame
    void Update()
    {
        wepButtons();

        if (cashTrack > player.GetComponent<PlayerMovement>().bank)
        {
            for(int i = 0; i < 4; i++)
            {
                gameManager.GetComponent<gameManager>().itemUpgradeGun(weps[i], wepsB[i]);
            }
            gameManager.GetComponent<gameManager>().itemUpgradePlayer();
            cashTrack = player.GetComponent<PlayerMovement>().bank;
        }
    }

    void wepButtons()
    {
        if (gameManager.GetComponent<gameManager>().revO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 1)
            {
                revolverT.text = "Equipped";
            }
            else
            {
                revolverT.text = "Equip";
            }
        }
        else
        {
            revolverT.text = "Cost: " + shotgunPrice;
        }

        if (gameManager.GetComponent<gameManager>().shotgunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 2)
            {
                shotgunT.text = "Equipped";
            }
            else
            {
                shotgunT.text = "Equip";
            }
        }
        else
        {
            shotgunT.text = "Cost: " + shotgunPrice;
        }

        if (gameManager.GetComponent<gameManager>().machinegunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 3)
            {
                machineGunT.text = "Equipped";
            }
            else
            {
                machineGunT.text = "Equip";
            }
        }
        else
        {
            machineGunT.text = "Cost: " + machineGunPrice;
        }

        if (gameManager.GetComponent<gameManager>().sniperO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum == 4)
            {
                sniperT.text = "Equipped";
            }
            else
            {
                sniperT.text = "Equip";
            }
        }
        else
        {
            sniperT.text = "Cost: " + sniperPrice;
        }
    }

    public void shotgunButton()
    {
        if (gameManager.GetComponent<gameManager>().shotgunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum != 2)
            {
                gameManager.GetComponent<gameManager>().wepNum = 2;
                revolver.SetActive(false);
                machineGun.SetActive(false);
                sniper.SetActive(false);
                shotgun.SetActive(true);
                shotgun.GetComponent<Gun>().fireDelay = false;
                shotgun.GetComponent<Gun>().isReload = false;
                shotgun.GetComponent<Gun>().ammo = shotgun.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = shotgun;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / shotgun.GetComponent<Gun>().reloadSpeed;
                player.GetComponent<PlayerMovement>().gun = shotgun;
            }
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().bank >= shotgunPrice)
            {
                player.GetComponent<PlayerMovement>().bank -= shotgunPrice;
                gameManager.GetComponent<gameManager>().shotgunO = true;
                gameManager.GetComponent<gameManager>().wepNum = 2;
                revolver.SetActive(false);
                machineGun.SetActive(false);
                sniper.SetActive(false);
                shotgun.SetActive(true);
                shotgun.GetComponent<Gun>().fireDelay = false;
                shotgun.GetComponent<Gun>().isReload = false;
                shotgun.GetComponent<Gun>().ammo = shotgun.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = shotgun;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / shotgun.GetComponent<Gun>().reloadSpeed;
                player.GetComponent<PlayerMovement>().gun = shotgun;
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
                revolver.SetActive(false);
                machineGun.SetActive(true);
                sniper.SetActive(false);
                shotgun.SetActive(false);
                machineGun.GetComponent<Gun>().fireDelay = false;
                machineGun.GetComponent<Gun>().isReload = false;
                machineGun.GetComponent<Gun>().ammo = machineGun.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = machineGun;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / machineGun.GetComponent<Gun>().reloadSpeed;
                player.GetComponent<PlayerMovement>().gun = machineGun;
            }
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().bank >= machineGunPrice)
            {
                player.GetComponent<PlayerMovement>().bank -= machineGunPrice;
                gameManager.GetComponent<gameManager>().machinegunO = true;
                gameManager.GetComponent<gameManager>().wepNum = 3;
                revolver.SetActive(false);
                machineGun.SetActive(true);
                sniper.SetActive(false);
                shotgun.SetActive(false);
                machineGun.GetComponent<Gun>().fireDelay = false;
                machineGun.GetComponent<Gun>().isReload = false;
                machineGun.GetComponent<Gun>().ammo = machineGun.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = machineGun;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / machineGun.GetComponent<Gun>().reloadSpeed;
                player.GetComponent<PlayerMovement>().gun = machineGun;
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
                revolver.SetActive(false);
                machineGun.SetActive(false);
                sniper.SetActive(true);
                shotgun.SetActive(false);
                sniper.GetComponent<Gun>().fireDelay = false;
                sniper.GetComponent<Gun>().isReload = false;
                sniper.GetComponent<Gun>().ammo = sniper.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = sniper;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / sniper.GetComponent<Gun>().reloadSpeed;
                player.GetComponent<PlayerMovement>().gun = sniper;
            }
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().bank >= sniperPrice)
            {
                player.GetComponent<PlayerMovement>().bank -= sniperPrice;
                gameManager.GetComponent<gameManager>().sniperO = true;
                gameManager.GetComponent<gameManager>().wepNum = 4;
                revolver.SetActive(false);
                machineGun.SetActive(false);
                sniper.SetActive(true);
                shotgun.SetActive(false);
                sniper.GetComponent<Gun>().fireDelay = false;
                sniper.GetComponent<Gun>().isReload = false;
                sniper.GetComponent<Gun>().ammo = sniper.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = sniper;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / sniper.GetComponent<Gun>().reloadSpeed;
                player.GetComponent<PlayerMovement>().gun = sniper;
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
                revolver.SetActive(true);
                machineGun.SetActive(false);
                sniper.SetActive(false);
                shotgun.SetActive(false);
                revolver.GetComponent<Gun>().fireDelay = false;
                revolver.GetComponent<Gun>().isReload = false;
                revolver.GetComponent<Gun>().ammo = revolver.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = revolver;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / revolver.GetComponent<Gun>().reloadSpeed;
                player.GetComponent<PlayerMovement>().gun = revolver;
            }
        }
    }

}

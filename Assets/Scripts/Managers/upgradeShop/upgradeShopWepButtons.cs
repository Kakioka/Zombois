using TMPro;
using UnityEngine;

public class upgradeShopWepButtons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    public GameObject UI;
    public GameObject revObj;
    public GameObject shotgunObj;
    public GameObject machinegunObj;
    public GameObject sniperObj;
    public int shotgunPrice;
    public int sniperPrice;
    public int machineGunPrice;
    public TextMeshProUGUI shotgun;
    public TextMeshProUGUI revolver;
    public TextMeshProUGUI machineGun;
    public TextMeshProUGUI sniper;


    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<upgradeShopManager>().player;
        gameManager = gameObject.GetComponent<upgradeShopManager>().gameManager;
        UI = gameObject.GetComponent<upgradeShopManager>().UI;
    }

    // Update is called once per frame
    void Update()
    {
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

    public void shotgunButton()
    {
        if (gameManager.GetComponent<gameManager>().shotgunO)
        {
            if (gameManager.GetComponent<gameManager>().wepNum != 2)
            {
                gameManager.GetComponent<gameManager>().wepNum = 2;
                revObj.SetActive(false);
                machinegunObj.SetActive(false);
                sniperObj.SetActive(false);
                shotgunObj.SetActive(true);
                shotgunObj.GetComponent<Gun>().fireDelay = false;
                shotgunObj.GetComponent<Gun>().isReload = false;
                shotgunObj.GetComponent<Gun>().ammo = shotgunObj.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = shotgunObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / shotgunObj.GetComponent<Gun>().reloadSpeed;
            }
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().bank >= shotgunPrice)
            {
                player.GetComponent<PlayerMovement>().bank -= shotgunPrice;
                gameManager.GetComponent<gameManager>().shotgunO = true;
                gameManager.GetComponent<gameManager>().wepNum = 2;
                revObj.SetActive(false);
                machinegunObj.SetActive(false);
                sniperObj.SetActive(false);
                shotgunObj.SetActive(true);
                shotgunObj.GetComponent<Gun>().fireDelay = false;
                shotgunObj.GetComponent<Gun>().isReload = false;
                shotgunObj.GetComponent<Gun>().ammo = shotgunObj.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = shotgunObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / shotgunObj.GetComponent<Gun>().reloadSpeed;
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
                revObj.SetActive(false);
                machinegunObj.SetActive(true);
                sniperObj.SetActive(false);
                shotgunObj.SetActive(false);
                machinegunObj.GetComponent<Gun>().fireDelay = false;
                machinegunObj.GetComponent<Gun>().isReload = false;
                machinegunObj.GetComponent<Gun>().ammo = machinegunObj.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = machinegunObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / machinegunObj.GetComponent<Gun>().reloadSpeed;
            }
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().bank >= machineGunPrice)
            {
                player.GetComponent<PlayerMovement>().bank -= machineGunPrice;
                gameManager.GetComponent<gameManager>().machinegunO = true;
                gameManager.GetComponent<gameManager>().wepNum = 3;
                revObj.SetActive(false);
                machinegunObj.SetActive(true);
                sniperObj.SetActive(false);
                shotgunObj.SetActive(false);
                machinegunObj.GetComponent<Gun>().fireDelay = false;
                machinegunObj.GetComponent<Gun>().isReload = false;
                machinegunObj.GetComponent<Gun>().ammo = machinegunObj.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = machinegunObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / machinegunObj.GetComponent<Gun>().reloadSpeed;
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
                revObj.SetActive(false);
                machinegunObj.SetActive(false);
                sniperObj.SetActive(true);
                shotgunObj.SetActive(false);
                sniperObj.GetComponent<Gun>().fireDelay = false;
                sniperObj.GetComponent<Gun>().isReload = false;
                sniperObj.GetComponent<Gun>().ammo = sniperObj.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = sniperObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / sniperObj.GetComponent<Gun>().reloadSpeed;
            }
        }
        else
        {
            if (player.GetComponent<PlayerMovement>().bank >= sniperPrice)
            {
                player.GetComponent<PlayerMovement>().bank -= sniperPrice;
                gameManager.GetComponent<gameManager>().sniperO = true;
                gameManager.GetComponent<gameManager>().wepNum = 4;
                revObj.SetActive(false);
                machinegunObj.SetActive(false);
                sniperObj.SetActive(true);
                shotgunObj.SetActive(false);
                sniperObj.GetComponent<Gun>().fireDelay = false;
                sniperObj.GetComponent<Gun>().isReload = false;
                sniperObj.GetComponent<Gun>().ammo = sniperObj.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = sniperObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / sniperObj.GetComponent<Gun>().reloadSpeed;
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
                revObj.SetActive(true);
                machinegunObj.SetActive(false);
                sniperObj.SetActive(false);
                shotgunObj.SetActive(false);
                revObj.GetComponent<Gun>().fireDelay = false;
                revObj.GetComponent<Gun>().isReload = false;
                revObj.GetComponent<Gun>().ammo = revObj.GetComponent<Gun>().maxAmmo;
                UI.GetComponent<UIManager>().gun = revObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1 / revObj.GetComponent<Gun>().reloadSpeed;
            }
        }
    }

}

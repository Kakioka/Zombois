using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class upgradeShopWepButtons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject UI;
    public GameObject revObj;
    public GameObject shotgunObj;
    public GameObject machinegunObj;
    public GameObject sniperObj;
    public int shotgunPrice;
    public int sniperPrice;
    public int machineGunPrice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                UI.GetComponent<UIManager>().gun = shotgunObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1/shotgunObj.GetComponent<Gun>().reloadSpeed;
            }
        }
        else
        {
            if (gameManager.GetComponent<gameManager>().bank >= shotgunPrice)
            {
                gameManager.GetComponent<gameManager>().bank -= shotgunPrice;
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
                revObj.SetActive(false);
                machinegunObj.SetActive(true);
                sniperObj.SetActive(false);
                shotgunObj.SetActive(false);
                machinegunObj.GetComponent<Gun>().fireDelay = false;
                UI.GetComponent<UIManager>().gun = machinegunObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1/machinegunObj.GetComponent<Gun>().reloadSpeed;
            }
        }
        else
        {
            if (gameManager.GetComponent<gameManager>().bank >= machineGunPrice)
            {
                gameManager.GetComponent<gameManager>().bank -= machineGunPrice;
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
                revObj.SetActive(false);
                machinegunObj.SetActive(false);
                sniperObj.SetActive(true);
                shotgunObj.SetActive(false);
                sniperObj.GetComponent<Gun>().fireDelay = false;
                UI.GetComponent<UIManager>().gun = sniperObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1/sniperObj.GetComponent<Gun>().reloadSpeed;
            }
        }
        else
        {
            if (gameManager.GetComponent<gameManager>().bank >= sniperPrice)
            {
                gameManager.GetComponent<gameManager>().bank -= sniperPrice;
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
                revObj.SetActive(true);
                machinegunObj.SetActive(false);
                sniperObj.SetActive(false);
                shotgunObj.SetActive(false);
                revObj.GetComponent<Gun>().fireDelay = false;
                UI.GetComponent<UIManager>().gun = revObj;
                UI.GetComponent<UIManager>().aniGun.speed = 1/revObj.GetComponent<Gun>().reloadSpeed;
            }
        }
    }

}

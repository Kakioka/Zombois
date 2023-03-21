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
    public int cashTrack;

    public List<GameObject> wepsB = new List<GameObject>();
    public List<GameObject> weps = new List<GameObject>();

    public List<GameObject> weaponCards = new List<GameObject>();

    public Transform wepPos;

    private GameObject weapCard;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<upgradeShopManager>().player;
        gameManager = GetComponent<upgradeShopManager>().gameManager;
        UI = GetComponent<upgradeShopManager>().UI;
        cashTrack = player.GetComponent<PlayerMovement>().bank;

        weapCard = Instantiate(weaponCards[Random.Range(0, weaponCards.Count-1)], wepPos);
        weapCard.GetComponent<weaponCard>().player = player;
        weapCard.GetComponent<weaponCard>().gameM = gameManager;
        weapCard.GetComponent<weaponCard>().upgradeShopWepButtons = GetComponent<upgradeShopWepButtons>();

        wepsB.Add(revolverB);
        wepsB.Add(shotgunB);
        wepsB.Add(machineGunB);  
        wepsB.Add(sniperB);

        weps.Add(revolver);
        weps.Add(shotgun);
        weps.Add(machineGun);
        weps.Add(sniper);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (cashTrack > player.GetComponent<PlayerMovement>().bank)
        {
            for(int i = 0; i < 4; i++)
            {
                gameManager.GetComponent<gameManager>().itemUpgradeGun(weps[i], wepsB[i]);
            }
            gameManager.GetComponent<gameManager>().itemUpgradePlayer();
            cashTrack = player.GetComponent<PlayerMovement>().bank;
            UI.GetComponent<UIManager>().aniGun.speed = 1 / UI.GetComponent<UIManager>().gun.GetComponent<Gun>().reloadSpeed;
        }
    }

    public void refreshWep()
    {
        Destroy(weapCard);
        weapCard = Instantiate(weaponCards[Random.Range(0, weaponCards.Count)], wepPos);
        weapCard.GetComponent<weaponCard>().player = player;
        weapCard.GetComponent<weaponCard>().gameM = gameManager;
        weapCard.GetComponent<weaponCard>().upgradeShopWepButtons = GetComponent<upgradeShopWepButtons>();
    }

    public void setWeapon()
    {
        switch (gameManager.GetComponent<gameManager>().wepNum)
        {
            case 1:
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
                break;
            case 2:
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
                break;
            case 3:
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
                break;
            case 4:
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
                break;
        }
    }
}

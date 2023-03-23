using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class upgradeShopWepButtons : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject player;
    public GameObject UI;

    public int cashTrack;

    public List<GameObject> weaponCards = new List<GameObject>();

    public Transform wepPos;

    private GameObject weapCard;

    private gameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<upgradeShopManager>().player;
        gameManager = GetComponent<upgradeShopManager>().gameManager;
        manager = gameManager.GetComponent<gameManager>();
        UI = GetComponent<upgradeShopManager>().UI;
        cashTrack = player.GetComponent<PlayerMovement>().bank;

        weapCard = Instantiate(weaponCards[Random.Range(0, weaponCards.Count-1)], wepPos);
        weapCard.GetComponent<weaponCard>().player = player;
        weapCard.GetComponent<weaponCard>().gameM = gameManager;
        weapCard.GetComponent<weaponCard>().upgradeShopWepButtons = GetComponent<upgradeShopWepButtons>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (cashTrack > player.GetComponent<PlayerMovement>().bank)
        {
            manager.itemUpgradeGun(manager.gun, manager.guns[manager.wepNum]);
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
        Destroy(manager.gun);
        manager.spawnWep(manager.wepNum);
        manager.itemUpgradeGun(manager.gun, manager.guns[manager.wepNum]);
        UI.GetComponent<UIManager>().gun = manager.gun;
        UI.GetComponent<UIManager>().aniGun.speed = 1 / manager.gun.GetComponent<Gun>().reloadSpeed;
    }
}

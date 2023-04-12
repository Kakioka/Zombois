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

        weapCard = Instantiate(weaponCards[Random.Range(0, weaponCards.Count)], wepPos);
        weapCard.GetComponent<weaponCard>().player = player;
        weapCard.GetComponent<weaponCard>().gameM = gameManager;
        weapCard.GetComponent<weaponCard>().upgradeShopWepButtons = GetComponent<upgradeShopWepButtons>();
    }

    public void updateInShop()
    {
        gameManager.GetComponent<gameManager>().itemUpgradePlayer();
        cashTrack = player.GetComponent<PlayerMovement>().bank;
        setWeapon();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refreshWep()
    {
        gameObject.GetComponent<AudioSource>().Play();
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
        manager.itemUpgradeGun(manager.gun, manager.guns[manager.wepNum]);
        UI.GetComponent<UIManager>().aniGun.speed = 1 / manager.gun.GetComponent<Gun>().reloadSpeed;
    }
}

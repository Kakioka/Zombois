using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    //player money
    public int bank = 0;

    //current player wep
    public int wepNum = 1;

    //player prefab
    public GameObject playerPref;
    //player obj
    public GameObject player;

    //gun prefabs
    public GameObject rev;
    public GameObject shotG;
    public GameObject snipe;
    public GameObject machineG;

    //gun obj
    public GameObject gun;

    //player upgrades
    public int moveUp;
    public int rangeUp;
    public int playerH = 3;

    //sister
    public GameObject sisPre;
    public GameObject sis;
    public int sisH = 3;

    //weapon upgrades
    public int projectileUp;
    public int damageUp;
    public int pierceUp;
    public int sizeUp;
    public int knockUp;
    public int speedUp;
    public int fireUp;
    public int reloadUp;

    //level count
    public int levelNum = 1;

    //stageManagerPrefabs
    public GameObject stage1ManagerPre;
    public GameObject upgradeShopManagerPre;
    public GameObject currManager;

    public bool revO = true;
    public bool shotgunO = false;
    public bool sniperO = false;
    public bool machinegunO = false;

    public float damageMultiI;
    public float damageMultiII;
    public float damageMultiIII;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnLevel(levelNum);
        }
    }

    void levelStart()
    {   
        player = Instantiate(playerPref, playerPref.transform.position, Quaternion.identity);
        player.GetComponent<PlayerMovement>().bank = bank;
        player.GetComponent<PlayerMovement>().health = playerH;
        sis = Instantiate(sisPre, sisPre.transform.position, Quaternion.identity);
        sis.GetComponent<Sister>().health = sisH;
        spawnWep(wepNum);
        wepUpgrade();
    }

    public void levelEnd()
    {
        bank = player.GetComponent<PlayerMovement>().bank;
        playerH = player.GetComponent<PlayerMovement>().health;
        sisH = sis.GetComponent<Sister>().health;
        levelNum++;
        spawnLevel(8);
    }

    void spawnWep(int num)
    {
        switch (num)
        {
            case 1:
                gun = Instantiate(rev, player.transform.position, player.transform.rotation);
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = player.GetComponent<PlayerMovement>().cam;
                break;

            case 2:
                gun = Instantiate(shotG, player.transform.position, player.transform.rotation);
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = player.GetComponent<PlayerMovement>().cam;
                break;

            case 3:
                gun = Instantiate(machineG, player.transform.position, player.transform.rotation);
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = player.GetComponent<PlayerMovement>().cam;
                break;

            case 4:
                gun = Instantiate(snipe, player.transform.position, player.transform.rotation);
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = player.GetComponent<PlayerMovement>().cam;
                break;
        }
    }

    void wepUpgrade() 
    {
        switch (damageUp) 
        {
            case 1:
                gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * 1.1f);
                break;

            case 2:
                gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * 1.2f);
                break;

            case 3:
                gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * 1.3f);
                break;
        }

        switch (speedUp)
        {
            case 1:
                gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * 1.1f;
                break;

            case 2:
                gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * 1.2f;
                break;

            case 3:
                gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * 1.3f;
                break;
        }

        switch (reloadUp)
        {
            case 1:
                gun.GetComponent<Gun>().reloadSpeed = gun.GetComponent<Gun>().reloadSpeed * 0.8f;
                break;

            case 2:
                gun.GetComponent<Gun>().reloadSpeed = gun.GetComponent<Gun>().reloadSpeed * 0.7f;
                break;

            case 3:
                gun.GetComponent<Gun>().reloadSpeed = gun.GetComponent<Gun>().reloadSpeed * 0.6f;
                break;
        }

        switch (fireUp)
        {
            case 1:
                gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * 0.9f;
                break;

            case 2:
                gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * 0.8f;
                break;

            case 3:
                gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * 0.7f;
                break;
        }

        switch (projectileUp)
        {
            case 1:
                gun.GetComponent<Gun>().projectiles += 1;
                break;

            case 2:
                gun.GetComponent<Gun>().projectiles += 2;
                break;

            case 3:
                gun.GetComponent<Gun>().projectiles += 3;
                break;
        }

        switch (pierceUp)
        {
            case 1:
                gun.GetComponent<Gun>().piecre += 1;
                break;

            case 2:
                gun.GetComponent<Gun>().piecre += 2;
                break;

            case 3:
                gun.GetComponent<Gun>().piecre += 3;
                break;
        }

        switch (sizeUp)
        {
            case 1:
                gun.GetComponent<Gun>().bulletSize += 0.25f;
                break;

            case 2:
                gun.GetComponent<Gun>().bulletSize += 0.5f;
                break;

            case 3:
                gun.GetComponent<Gun>().bulletSize += 0.75f;
                break;
        }

        switch (knockUp)
        {
            case 1:
                gun.GetComponent<Gun>().knockBack += 1;
                break;

            case 2:
                gun.GetComponent<Gun>().knockBack += 2;
                break;

            case 3:
                gun.GetComponent<Gun>().knockBack += 3;
                break;
        }
    }

    public void spawnLevel(int level)
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Stage1");
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6:
                break;

            case 7:
                break;

            case 8:
                SceneManager.LoadScene("UpgradeShop");
                break;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += levelLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= levelLoaded;
    }

    void levelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Stage1")
        {
            levelStart();
            currManager = Instantiate(stage1ManagerPre);
            currManager.GetComponent<stage1Manager>().gameM = this.gameObject;
            currManager.GetComponent<stage1Manager>().player = player;
        }

        if (scene.name == "UpgradeShop")
        {
            currManager = Instantiate(upgradeShopManagerPre);
            currManager.GetComponent<upgradeShopManager>().gameManager = this.gameObject;
        }
    }


}

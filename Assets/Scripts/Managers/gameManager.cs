using Cinemachine;
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
    public GameObject rev, shotG, snipe, machineG;

    //gun obj
    public GameObject gun;

    public int playerH = 3;

    //sister
    public GameObject sisPre, sis;
    public int sisH = 3;

    //item counts
    public List<int> itemCounts = new List<int>();

    //track items held
    public List<int> itemEquiped = new List<int>();

    //item stats
    public float stim;
    public float run;
    public float gunpowder;
    public float bangDmg, bangSize, bangFire;
    public float fullAmmo;
    public float MultiDmg;
    public float leash;
    public float mag;
    public float highDmg, highSpeed, highAmmo;
    public float lowAmmo, lowDmg;
    public GameObject snow;
    public float snowRadius, snowPower;
    public GameObject bubble;
    public GameObject missile;
    public float powerDmg, powerSpeed;

    

    //track if upgrade exists
    private GameObject snowG;
    private GameObject bubbleG;
    private GameObject missileG;

    //level count
    public int levelNum = 0;

    //stageManagerPrefabs
    public List<GameObject> stageManager = new List<GameObject>();
    public GameObject currManager;

    public bool revO = true;
    public bool shotgunO = false;
    public bool sniperO = false;
    public bool machinegunO = false;

    public GameObject UI;
    public Camera cam;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;

    public GameObject currUI;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = AudioListener.volume;
        Vector2 hotspot = new Vector2(cursorTexture.width / 2f, cursorTexture.height / 2f);
        DontDestroyOnLoad(this.gameObject);
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            levelNum++;
            spawnLevel(levelNum);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            levelNum++;
            spawnLevel(8);
        }
    }

    void levelStart()
    {
        Time.timeScale = 1;
        spawnPlayer();
        spawnWep(wepNum);
        itemUpgrade();
    }

    void upgradeStart()
    {
        spawnPlayer();
        player.transform.position = new Vector3(0, -2, 10);
        sis.transform.position = new Vector3(0.8f, -2, 10);
    }

    void spawnPlayer()
    {
        player = Instantiate(playerPref, playerPref.transform.position, Quaternion.identity);
        player.GetComponent<PlayerMovement>().bank = bank;
        player.GetComponent<PlayerMovement>().health = playerH;
        sis = Instantiate(sisPre, sisPre.transform.position, Quaternion.identity);
        sis.GetComponent<Sister>().health = sisH;
        sis.GetComponent<Sister>().player = player;
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
                break;
            case 2:
                gun = Instantiate(shotG, player.transform.position, player.transform.rotation);
                break;

            case 3:
                gun = Instantiate(machineG, player.transform.position, player.transform.rotation);
                break;

            case 4:
                gun = Instantiate(snipe, player.transform.position, player.transform.rotation);
                break;
        }
        gun.GetComponent<Gun>().player = player;
        gun.GetComponent<Gun>().cam = cam;
        player.GetComponent<PlayerMovement>().gun = gun;
    }

    public void itemUpgrade() 
    {
        gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * ((1 - (stim * itemCounts[0])) * (1 + (bangFire * itemCounts[4])));
        gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * (1 + (bangDmg * itemCounts[4]) + (highDmg * itemCounts[3]) + (powerDmg * itemCounts[3])) * (1 - (MultiDmg * itemCounts[6]) - (lowDmg * itemCounts[13])));
        gun.GetComponent<Gun>().bulletSize = gun.GetComponent<Gun>().bulletSize * (1 + (bangSize * itemCounts[4]));
        gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * (1 + (gunpowder * itemCounts[2])) * (1 + (highSpeed * itemCounts[3])) * (1 - (powerSpeed * itemCounts[12]));
        gun.GetComponent<Gun>().piecre = gun.GetComponent<Gun>().piecre + itemCounts[2] + itemCounts[12];
        float temp = 1 - (fullAmmo * itemCounts[5]);
        if (temp < 0.4 && itemCounts[3] > 0)
        {
            temp = 0.4f;
        }
        float temp2 = 1 - (highAmmo * itemCounts[3]);
        if (temp < 0.4 && itemCounts[5] > 0)
        {
            temp2 = 0.4f;
        }
        gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gun.GetComponent<Gun>().ammo * (1 + (lowAmmo * itemCounts[13])) * (temp * temp2));
        if (gun.GetComponent<Gun>().maxAmmo < 1) 
        {
            gun.GetComponent<Gun>().maxAmmo = 1;
        }
        gun.GetComponent<Gun>().projectiles = gun.GetComponent<Gun>().projectiles + itemCounts[5] + itemCounts[6];
        if (gun.GetComponent<Gun>().projectiles > 7) 
        {
            gun.GetComponent<Gun>().projectiles = 7;
        }
        player.GetComponent<PlayerMovement>().moveSpeed = player.GetComponent<PlayerMovement>().moveSpeed * (1 + (run * itemCounts[1]));
        sis.GetComponent<Sister>().moveSpeed = sis.GetComponent<Sister>().moveSpeed * (1 + (leash * itemCounts[7]));
        player.GetComponent<PlayerMovement>().pickUpRadius = player.GetComponent<PlayerMovement>().pickUpRadius * (1 + (mag * itemCounts[8]));
        sis.GetComponent<Sister>().pickUpRadius = sis.GetComponent<Sister>().pickUpRadius * (1 + (mag * itemCounts[8]));
        if (itemCounts[9] > 0) 
        {
            GameObject snowObj = Instantiate(snow, player.transform);
            snowObj.GetComponent<Snow>().radius *= (1 + (snowRadius * itemCounts[9]));
            snowObj.GetComponent<Snow>().speedMod *= (1 - (snowPower * itemCounts[9]));
        }

        if (itemCounts[10] > 0)
        {
            itemCounts[10]--;
            Instantiate(bubble, player.transform);
            Instantiate(bubble, sis.transform);
        }

        if (itemCounts[11] > 0)
        {
            GameObject miss = Instantiate(missile, player.transform);
            miss.GetComponent<MissileLauncher>().damage += (itemCounts[11] * 2);
            miss.GetComponent<MissileLauncher>().player = player;
        }

        if (itemCounts[14] > 0) 
        {
            gun.GetComponent<Gun>().bleedOn = true;
            gun.GetComponent<Gun>().bleedLvl = itemCounts[14];
        }

        if (itemCounts[15] > 0) 
        {
            gun.GetComponent<Gun>().splinterOn = true;
            gun.GetComponent<Gun>().splintLvl = itemCounts[15];
        }
    }

    public void itemUpgradeGun(GameObject gun, GameObject gunb)
    {
        gun.GetComponent<Gun>().fireRate = gunb.GetComponent<Gun>().fireRate * ((1 - (stim * itemCounts[0])) * (1 + (bangFire * itemCounts[4])));
        gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gunb.GetComponent<Gun>().damage * (1 + (bangDmg * itemCounts[4]) + (highDmg * itemCounts[3]) + (powerDmg * itemCounts[3])) * (1 - (MultiDmg * itemCounts[6]) - (lowDmg * itemCounts[13])));
        gun.GetComponent<Gun>().bulletSize = gunb.GetComponent<Gun>().bulletSize * (1 + (bangSize * itemCounts[4]));
        gun.GetComponent<Gun>().bulletForce = gunb.GetComponent<Gun>().bulletForce * (1 + (gunpowder * itemCounts[2])) * (1 + (highSpeed * itemCounts[3])) * (1 - (powerSpeed * itemCounts[12]));
        gun.GetComponent<Gun>().piecre = gunb.GetComponent<Gun>().piecre + itemCounts[2] + itemCounts[12];
        float temp = 1 - (fullAmmo * itemCounts[5]);
        if (temp < 0.4 && itemCounts[3] > 0) 
        {
            temp = 0.4f;
        }
        float temp2 = 1 - (highAmmo * itemCounts[3]);
        if (temp < 0.4 && itemCounts[5] > 0)
        {
            temp2 = 0.4f;
        }
        gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gunb.GetComponent<Gun>().ammo * (1 + (lowAmmo * itemCounts[13])) * (temp * temp2));
        if (gun.GetComponent<Gun>().maxAmmo < 1)
        {
            gun.GetComponent<Gun>().maxAmmo = 1;
        }
        gun.GetComponent<Gun>().projectiles = gunb.GetComponent<Gun>().projectiles + itemCounts[5] + itemCounts[6];
        if (gun.GetComponent<Gun>().projectiles > 7)
        {
            gun.GetComponent<Gun>().projectiles = 7;
        }
        if (itemCounts[14] > 0)
        {
            gun.GetComponent<Gun>().bleedOn = true;
            gun.GetComponent<Gun>().bleedLvl = itemCounts[14];
        }

        if (itemCounts[15] > 0)
        {
            gun.GetComponent<Gun>().splinterOn = true;
            gun.GetComponent<Gun>().splintLvl = itemCounts[15];
        }
    }

    public void itemUpgradePlayer() 
    {
        player.GetComponent<PlayerMovement>().moveSpeed = playerPref.GetComponent<PlayerMovement>().moveSpeed * (1 + (run * itemCounts[1]));
        sis.GetComponent<Sister>().moveSpeed = sisPre.GetComponent<Sister>().moveSpeed * (1 + (leash * itemCounts[7]));
        player.GetComponent<PlayerMovement>().pickUpRadius = playerPref.GetComponent<PlayerMovement>().pickUpRadius * (1 + (mag * itemCounts[8]));
        sis.GetComponent<Sister>().pickUpRadius = sisPre.GetComponent<Sister>().pickUpRadius * (1 + (mag * itemCounts[8]));
        if (itemCounts[9] > 0)
        {
            if (snowG == null) 
            {
                snowG = Instantiate(snow, player.transform);
            }
            snowG.GetComponent<Snow>().radius = snow.GetComponent<Snow>().radius * (1 + (snowRadius * itemCounts[9]));
            snowG.GetComponent<Snow>().speedMod = snow.GetComponent<Snow>().radius * (1 - (snowPower * itemCounts[9]));
        }

        if (itemCounts[10] > 0)
        {
            if (bubbleG == null) 
            {
                bubbleG = Instantiate(bubble, player.transform);
                Instantiate(bubble, sis.transform);
            }  
        }

        if (itemCounts[11] > 0)
        {
            if (missileG == null) 
            {
                missileG = Instantiate(missile, player.transform);
                missileG.GetComponent<MissileLauncher>().player = player;
            }
            missileG.GetComponent<MissileLauncher>().damage = missile.GetComponent<MissileLauncher>().damage + (itemCounts[11] * 2);
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
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;

            case 4:
                SceneManager.LoadScene("Stage4");
                break;

            case 5:
                SceneManager.LoadScene("Stage5");
                break;

            case 6:
                SceneManager.LoadScene("Stage6");
                break;

            case 7:
                SceneManager.LoadScene("Stage7");
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
        if (scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }

        if (scene.name == "Tutorial")
        {
            Destroy(gameObject);
        }

        if (scene.name == "Stage1")
        {
            levelStart();
            currManager = Instantiate(stageManager[0]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "Stage2")
        {
            levelStart();
            currManager = Instantiate(stageManager[1]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "Stage3")
        {
            levelStart();
            currManager = Instantiate(stageManager[2]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "Stage4")
        {
            levelStart();
            currManager = Instantiate(stageManager[3]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "Stage5")
        {
            levelStart();
            currManager = Instantiate(stageManager[4]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "Stage6")
        {
            levelStart();
            currManager = Instantiate(stageManager[5]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "Stage7")
        {
            levelStart();
            currManager = Instantiate(stageManager[6]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "UpgradeShop")
        {
            Time.timeScale = 1;
            currManager = Instantiate(stageManager[7]);
            currUI = Instantiate(UI);
            upgradeStart();
            cam.gameObject.transform.position = Vector2.zero;
            player.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
            switch (wepNum)
            {
                case 1:
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgun = gun;
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machineGun = gun;
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniper = gun;
                    gun.SetActive(false);
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revolver = gun;
                    break;
                case 2:
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revolver = gun;
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machineGun = gun;
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniper = gun;
                    gun.SetActive(false);
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgun = gun;
                    break;
                case 3:
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revolver = gun;
                    gun.SetActive(false);
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgun = gun;
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniper = gun;
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machineGun = gun;
                    break;
                case 4:
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revolver = gun;
                    gun.SetActive(false);
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgun = gun;
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machineGun = gun;
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniper = gun;
                    break;
            }
            uiStart(currUI);
            currManager.GetComponent<upgradeShopManager>().gameManager = this.gameObject;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currManager.GetComponentInChildren<upgradeShopManager>().UI = currUI;
            currManager.GetComponent<upgradeShopManager>().player = player;
            currManager.GetComponent<upgradeShopManager>().sister = sis;
            itemUpgrade();
            player.GetComponent<PlayerMovement>().gun = gun;
        }
    }

    void uiStart(GameObject currUI)
    {
        currUI.GetComponent<UIManager>().player = player;
        currUI.GetComponent<UIManager>().sister = sis;
        currUI.GetComponent<UIManager>().gun = gun;
        currUI.GetComponent<UIManager>().gameManager = gameObject;
        currUI.GetComponentInChildren<Canvas>().worldCamera = cam;
    }

    public void itemListUpdate() 
    {
        for(int i = 0; i < itemCounts.Count; i++) 
        {
            if (itemCounts[i] == 1 && !itemEquiped.Contains(i)) 
            {
                itemEquiped.Add(i);
            }
        }
        currUI.GetComponent<UIManager>().updateItemList();
    }
}

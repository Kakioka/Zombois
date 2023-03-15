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
    public GameObject rev;
    public GameObject shotG;
    public GameObject snipe;
    public GameObject machineG;

    //gun obj
    public GameObject gun;

    public int playerH = 3;

    //sister
    public GameObject sisPre;
    public GameObject sis;
    public int sisH = 3;

    //item counts
    public List<int> itemCounts = new List<int>();

    //item stats
    public float stim;
    public float run;
    public float gunpowder;
    public float bangDmg, bangSize, bangFire;
    public float fullAmmo;
    public float MultiDmg;
    public float leash;
    public float mag;
    public float powerDmg, powerSpeed, powerAmmo;
    public float lowAmmo, lowDmg;
    public GameObject snow;
    public float snowRadius, snowPower;

    //level count
    public int levelNum = 0;

    //stageManagerPrefabs
    public GameObject stage1ManagerPre;
    public GameObject stage2ManagerPre;
    public GameObject stage3ManagerPre;
    public GameObject stage4ManagerPre;
    public GameObject stage5ManagerPre;
    public GameObject stage6ManagerPre;
    public GameObject stage7ManagerPre;
    public GameObject upgradeShopManagerPre;
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
        //playerUpgrade();
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
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = cam;
                break;
            case 2:
                gun = Instantiate(shotG, player.transform.position, player.transform.rotation);
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = cam;
                break;

            case 3:
                gun = Instantiate(machineG, player.transform.position, player.transform.rotation);
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = cam;
                break;

            case 4:
                gun = Instantiate(snipe, player.transform.position, player.transform.rotation);
                gun.GetComponent<Gun>().player = player;
                gun.GetComponent<Gun>().cam = cam;
                break;
        }
    }

    public void itemUpgrade() 
    {
        gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * (1 + (stim * itemCounts[0])) * (1 - (bangFire * itemCounts[3]) - (lowDmg * itemCounts[12]));
        gun.GetComponent<Gun>().damage = Mathf.RoundToInt(gun.GetComponent<Gun>().damage * (1 + (bangDmg * itemCounts[3]) + (powerDmg * itemCounts[11])) * (1 -(MultiDmg * itemCounts[5])));
        gun.GetComponent<Gun>().bulletSize = gun.GetComponent<Gun>().bulletSize * (1 + (bangSize * itemCounts[3]));
        gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * (1 + (gunpowder * itemCounts[2]));
        gun.GetComponent<Gun>().piecre = gun.GetComponent<Gun>().piecre + itemCounts[2];
        gun.GetComponent<Gun>().ammo = Mathf.RoundToInt(gun.GetComponent<Gun>().ammo * (1 + (lowAmmo * itemCounts[12])) * (1 - (fullAmmo * itemCounts[4]) - (powerAmmo * itemCounts[11])));
        gun.GetComponent<Gun>().projectiles = gun.GetComponent<Gun>().projectiles + itemCounts[4] + itemCounts[5];

        player.GetComponent<PlayerMovement>().moveSpeed = player.GetComponent<PlayerMovement>().moveSpeed * (1 + (run * itemCounts[1]) + (leash * itemCounts[6]));
        sis.GetComponent<Sister>().moveSpeed = sis.GetComponent<Sister>().moveSpeed * (1 + (leash * itemCounts[6]));
        player.GetComponent<PlayerMovement>().pickUpRadius = player.GetComponent<PlayerMovement>().pickUpRadius * (1 + (mag * itemCounts[7]));

        if (itemCounts[8] > 0) 
        {
            GameObject snowObj = Instantiate(snow, player.transform);
            snowObj.GetComponent<Snow>().radius = snowObj.GetComponent<Snow>().radius * (1 + (snowRadius * itemCounts[8]));
            snowObj.GetComponent<Snow>().speedMod = snowObj.GetComponent<Snow>().radius * (1 - (snowPower * itemCounts[8]));
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
            currManager = Instantiate(stage1ManagerPre);
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
            currManager = Instantiate(stage2ManagerPre);
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
            currManager = Instantiate(stage3ManagerPre);
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
            currManager = Instantiate(stage4ManagerPre);
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
            currManager = Instantiate(stage5ManagerPre);
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
            currManager = Instantiate(stage6ManagerPre);
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
            currManager = Instantiate(stage7ManagerPre);
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
            currManager = Instantiate(upgradeShopManagerPre);
            currUI = Instantiate(UI);
            upgradeStart();
            cam.gameObject.transform.position = Vector2.zero;
            player.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
            switch (wepNum)
            {
                case 1:
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgunObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machinegunObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniperObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revObj = gun;
                    //wepUpgrade();
                    break;
                case 2:
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machinegunObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniperObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgunObj = gun;
                    //wepUpgrade();
                    break;
                case 3:
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgunObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniperObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machinegunObj = gun;
                    //wepUpgrade();
                    break;
                case 4:
                    spawnWep(1);
                    currManager.GetComponent<upgradeShopWepButtons>().revObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(2);
                    currManager.GetComponent<upgradeShopWepButtons>().shotgunObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(3);
                    currManager.GetComponent<upgradeShopWepButtons>().machinegunObj = gun;
                    //wepUpgrade();
                    gun.SetActive(false);
                    spawnWep(4);
                    currManager.GetComponent<upgradeShopWepButtons>().sniperObj = gun;
                    //wepUpgrade();
                    break;
            }
            uiStart(currUI);
            currManager.GetComponent<upgradeShopManager>().gameManager = this.gameObject;
            currManager.GetComponentInChildren<Canvas>().worldCamera = cam;
            currManager.GetComponentInChildren<upgradeShopManager>().UI = currUI;
            currManager.GetComponent<upgradeShopManager>().player = player;
            currManager.GetComponent<upgradeShopManager>().sister = sis;
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
}

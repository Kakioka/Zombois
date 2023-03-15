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

    //player upgrades
    public int moveUp;
    public int rangeUp;
    public int sisMoveUp;
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
    public int ammoUp;

    //item counts
    public List<int> itemCounts = new List<int>();

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

    public float damageI;
    public float damageII;
    public float damageIII;

    public float ammoI;
    public float ammoII;
    public float ammoIII;

    public float fireRateI;
    public float fireRateII;
    public float fireRateIII;

    public float knockBackI;
    public float knockBackII;
    public float knockBackIII;

    public float reloadI;
    public float reloadII;
    public float reloadIII;

    public float bulletI;
    public float bulletII;
    public float bulletIII;

    public int pierceI;
    public int pierceII;
    public int pierceIII;

    public float sizeI;
    public float sizeII;
    public float sizeIII;

    public float bulletSpeedI;
    public float bulletSpeedII;
    public float bulletSpeedIII;

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
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.T))
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
        playerUpgrade();
        spawnWep(wepNum);
        wepUpgrade(gun);
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

    public void playerUpgrade()
    {
        switch (moveUp)
        {
            case 1:
                player.GetComponent<PlayerMovement>().moveSpeed += 0.5f;
                break;
            case 2:
                player.GetComponent<PlayerMovement>().moveSpeed += 1f;
                break;
            case 3:
                player.GetComponent<PlayerMovement>().moveSpeed += 1.5f;
                break;
        }

        switch (rangeUp)
        {
            case 1:
                player.GetComponent<PlayerMovement>().pickUpRadius += 0.3f;
                break;
            case 2:
                player.GetComponent<PlayerMovement>().pickUpRadius += 0.6f;
                break;
            case 3:
                player.GetComponent<PlayerMovement>().pickUpRadius += 1f;
                break;
        }

        switch (sisMoveUp)
        {
            case 1:
                sis.GetComponent<Sister>().moveSpeed += 0.3f;
                break;
            case 2:
                sis.GetComponent<Sister>().moveSpeed += 0.6f;
                break;
            case 3:
                sis.GetComponent<Sister>().moveSpeed += 0.9f;
                break;
        }
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

    public void wepUpgrade(GameObject gun)
    {
        switch (ammoUp)
        {
            case 1:
                gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gun.GetComponent<Gun>().maxAmmo * ammoI);
                break;

            case 2:
                gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gun.GetComponent<Gun>().maxAmmo * ammoII);
                break;

            case 3:
                gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gun.GetComponent<Gun>().maxAmmo * ammoIII);
                break;
        }

        switch (damageUp)
        {
            case 1:
                gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * damageI);
                break;

            case 2:
                gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * damageII);
                break;

            case 3:
                gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * damageIII);
                break;
        }

        switch (speedUp)
        {
            case 1:
                gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * bulletSpeedI;
                break;

            case 2:
                gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * bulletSpeedII;
                break;

            case 3:
                gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * bulletSpeedIII;
                break;
        }

        switch (reloadUp)
        {
            case 1:
                gun.GetComponent<Gun>().reloadSpeed = gun.GetComponent<Gun>().reloadSpeed * reloadI;
                break;

            case 2:
                gun.GetComponent<Gun>().reloadSpeed = gun.GetComponent<Gun>().reloadSpeed * reloadII;
                break;

            case 3:
                gun.GetComponent<Gun>().reloadSpeed = gun.GetComponent<Gun>().reloadSpeed * reloadIII;
                break;
        }

        switch (fireUp)
        {
            case 1:
                gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * fireRateI;
                break;

            case 2:
                gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * fireRateII;
                break;

            case 3:
                gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * fireRateIII;
                break;
        }

        switch (projectileUp)
        {
            case 1:
                gun.GetComponent<Gun>().projectiles += 1;
                gun.GetComponent<Gun>().damage = Mathf.FloorToInt(gun.GetComponent<Gun>().damage * bulletI);
                break;

            case 2:
                gun.GetComponent<Gun>().projectiles += 2;
                gun.GetComponent<Gun>().damage = Mathf.FloorToInt(gun.GetComponent<Gun>().damage * bulletII);
                break;

            case 3:
                gun.GetComponent<Gun>().projectiles += 3;
                gun.GetComponent<Gun>().damage = Mathf.FloorToInt(gun.GetComponent<Gun>().damage * bulletIII);
                break;
        }

        switch (pierceUp)
        {
            case 1:
                gun.GetComponent<Gun>().piecre += pierceI;
                break;

            case 2:
                gun.GetComponent<Gun>().piecre += pierceII;
                break;

            case 3:
                gun.GetComponent<Gun>().piecre += pierceIII;
                break;
        }

        switch (sizeUp)
        {
            case 1:
                gun.GetComponent<Gun>().bulletSize += sizeI;
                break;

            case 2:
                gun.GetComponent<Gun>().bulletSize += sizeII;
                break;

            case 3:
                gun.GetComponent<Gun>().bulletSize += sizeIII;
                break;
        }

        switch (knockUp)
        {
            case 1:
                gun.GetComponent<Gun>().knockBack += knockBackI;
                break;

            case 2:
                gun.GetComponent<Gun>().knockBack += knockBackII;
                break;

            case 3:
                gun.GetComponent<Gun>().knockBack += knockBackIII;
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

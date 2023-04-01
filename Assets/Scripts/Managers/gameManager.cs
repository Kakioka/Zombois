using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    //player money
    public int bank = 0;

    //current player wep
    public int wepNum = 0;

    //player prefab
    public GameObject playerPref;

    //player obj
    public GameObject player;

    //gun prefabs
    public List<GameObject> guns = new List<GameObject>();

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
    public float fullAmmo, fullReload;
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
    public float glove;
    [SerializeField]
    private GameObject lightHouse;
    [SerializeField]
    private GameObject cat;
    [SerializeField]
    private GameObject beats;
    [SerializeField]
    private float bell;
    [SerializeField]
    private GameObject matrix;


    //track if upgrade exists
    private GameObject snowG, bubbleG, bubbleS, missileG, lightG, catG, beatG, matrixG;

    //level count
    public int levelNum = 0;

    //stageManagerPrefabs
    public List<GameObject> stageManager = new List<GameObject>();
    public GameObject currManager;
    public GameObject UI;

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
        itemUpgradeGun(gun, guns[wepNum]);
        itemUpgradePlayer();
    }

    void upgradeStart()
    {
        spawnPlayer();
        player.transform.position = new Vector3(0, -2, 10);
        sis.transform.position = new Vector3(0.8f, -2, 10);
        spawnWep(wepNum);
        itemUpgradeGun(gun, guns[wepNum]);
        itemUpgradePlayer();
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

    public void spawnWep(int num)
    {
        gun = Instantiate(guns[num], player.transform.position, player.transform.rotation);   
        gun.GetComponent<Gun>().player = player;
        player.GetComponent<PlayerMovement>().gun = gun;
    }

    /*public void itemUpgrade() 
    {
        //upgrade gun
        //firerate
        gun.GetComponent<Gun>().fireRate = gun.GetComponent<Gun>().fireRate * ((1 - (stim * itemCounts[0])) * (1 + (bangFire * itemCounts[4])));
        //damage
        gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * Mathf.Pow(2,itemCounts[17]) * (1 + (bangDmg * itemCounts[4]) + (highDmg * itemCounts[3]) + (powerDmg * itemCounts[12])) * (1 - (MultiDmg * itemCounts[6]) - (lowDmg * itemCounts[13])));
        //damage reduction cap
        if (gun.GetComponent<Gun>().damage <= 0) 
        {
            gun.GetComponent<Gun>().damage = 1;
        }
        //bullet size
        gun.GetComponent<Gun>().bulletSize = gun.GetComponent<Gun>().bulletSize * (1 + (bangSize * itemCounts[4]));
        //explosion size for explosives increases with bullet size
        gun.GetComponent<Gun>().boomScale = gun.GetComponent<Gun>().boomScale * (1 + (bangSize * itemCounts[4]));
        //bullet speed
        gun.GetComponent<Gun>().bulletForce = gun.GetComponent<Gun>().bulletForce * (1 + (gunpowder * itemCounts[2])) * (1 + (highSpeed * itemCounts[3])) * (1 - (powerSpeed * itemCounts[12]));
        //pierce
        gun.GetComponent<Gun>().piecre = gun.GetComponent<Gun>().piecre + itemCounts[2] + itemCounts[12];
        //reload speed
        gun.GetComponent<Gun>().reloadSpeed = gun.GetComponent<Gun>().reloadSpeed * (1 + (fullReload * itemCounts[5]) * (1 - (glove * itemCounts[16])));
        //ammo reduction cap calulations
        float temp = 1 - (fullAmmo * itemCounts[5]);
        if (temp < 0.3 && itemCounts[3] > 0)
        {
            temp = 0.3f;
        }
        float temp2 = 1 - (highAmmo * itemCounts[3]);
        if (temp < 0.3 && itemCounts[5] > 0)
        {
            temp2 = 0.3f;
        }
        //ammo
        gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gun.GetComponent<Gun>().ammo * (1 + (lowAmmo * itemCounts[13])) * (temp * temp2));
        //ammo reduction cap
        if (gun.GetComponent<Gun>().maxAmmo < 1) 
        {
            gun.GetComponent<Gun>().maxAmmo = 1;
        }
        //bullet up
        gun.GetComponent<Gun>().projectiles = gun.GetComponent<Gun>().projectiles + itemCounts[5] + itemCounts[6];
        //knockback
        gun.GetComponent<Gun>().knockBack = gun.GetComponent<Gun>().knockBack * (1 + (bell * itemCounts[24]));

        //upgrade player
        player.GetComponent<PlayerMovement>().moveSpeed = player.GetComponent<PlayerMovement>().moveSpeed * (1 + (run * itemCounts[1]));
        sis.GetComponent<Sister>().moveSpeed = sis.GetComponent<Sister>().moveSpeed * (1 + (leash * itemCounts[7]));
        player.GetComponent<PlayerMovement>().pickUpRadius = player.GetComponent<PlayerMovement>().pickUpRadius * (1 + (mag * itemCounts[8]));
        sis.GetComponent<Sister>().pickUpRadius = sis.GetComponent<Sister>().pickUpRadius * (1 + (mag * itemCounts[8]));
        sis.GetComponent<Sister>().maxHealth -= itemCounts[17];
        player.GetComponent<PlayerMovement>().speedReduction = player.GetComponent<PlayerMovement>().speedReduction * (1 + (bell * itemCounts[24]));

        if (sis.GetComponent<Sister>().health > sis.GetComponent<Sister>().maxHealth)
        {
            sis.GetComponent<Sister>().health = sis.GetComponent<Sister>().maxHealth;
            sisH = sis.GetComponent<Sister>().maxHealth;
        }
        if (itemCounts[9] > 0) 
        {
            snowG = Instantiate(snow, player.transform);
            float snowScale = snowG.transform.localScale.x * (1 + (snowRadius * itemCounts[9]));
            snowG.transform.localScale = new Vector3(snowScale,snowScale,snowScale);
            snowG.GetComponent<Snow>().speedMod *= (1 - (snowPower * itemCounts[9]));
        }

        if (itemCounts[10] > 0)
        {
            bubbleG = Instantiate(bubble, player.transform);
            GameObject bubbleS = Instantiate(bubble, sis.transform);
            bubbleG.GetComponent<Bubble>().bubbleLvl = itemCounts[10];
            bubbleS.GetComponent<Bubble>().bubbleLvl = itemCounts[10];
        }

        if (itemCounts[11] > 0)
        {
            missileG = Instantiate(missile, player.transform);
            missileG.GetComponent<MissileLauncher>().missileLvl = itemCounts[11];
            missileG.GetComponent<MissileLauncher>().player = player;
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

        if (itemCounts[18] > 0)
        {
            lightG = Instantiate(lightHouse, sis.transform);
            lightG.GetComponent<Lighthouse>().lightLvl = itemCounts[18];
        }

        if (itemCounts[19] > 0)
        {
            gun.GetComponent<Gun>().burnOn = true;
            gun.GetComponent<Gun>().burnLvl = itemCounts[19];
        }

        if (itemCounts[20] > 0)
        {
            gun.GetComponent<Gun>().freezeOn = true;
            gun.GetComponent<Gun>().freezeLvl = itemCounts[20];
        }

        if (itemCounts[21] > 0) 
        {
            catG = Instantiate(cat, player.transform.position, Quaternion.identity);
            catG.GetComponent<Cat>().damage = cat.GetComponent<Cat>().damage + (5 * (itemCounts[21] - 1));
            catG.GetComponent<Cat>().attackCD = catG.GetComponent<Cat>().attackCD * (1-(0.1f*itemCounts[21]));
            catG.GetComponent<Cat>().moveSpeed = catG.GetComponent<Cat>().moveSpeed * (1 + (0.2f * itemCounts[21]));
            catG.GetComponent<Cat>().player = player;
        }

        if (itemCounts[22] > 0)
        {
            beatG = Instantiate(beats);
            beatG.GetComponent<BeatsManager>().player = player;
            beatG.GetComponent<BeatsManager>().beatsLvl = itemCounts[22];
        }

        if (itemCounts[23] > 0) 
        {
            player.GetComponent<PlayerMovement>().coinOn = true;
            player.GetComponent<PlayerMovement>().coinLvl = itemCounts[23];
        }

        if (itemCounts[25] > 0)
        {
            gun.GetComponent<Gun>().tridentOn = true;
            gun.GetComponent<Gun>().tridentLvl = itemCounts[25];
        }

        if (itemCounts[26] > 0)
        {
            gun.GetComponent<Gun>().laserOn = true;
            gun.GetComponent<Gun>().laserLvl = itemCounts[26];
        }
    }*/

    public void itemUpgradeGun(GameObject gun, GameObject gunb)
    {
        gun.GetComponent<Gun>().fireRate = gunb.GetComponent<Gun>().fireRate * ((1 - (stim * itemCounts[0])) * (1 + (bangFire * itemCounts[4])));
        gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gunb.GetComponent<Gun>().damage * Mathf.Pow(2,itemCounts[17]) * (1 + (bangDmg * itemCounts[4]) + (highDmg * itemCounts[3]) + (powerDmg * itemCounts[12])) * (1 - (MultiDmg * itemCounts[6]) - (lowDmg * itemCounts[13])));
        if (gun.GetComponent<Gun>().damage <= 0)
        {
            gun.GetComponent<Gun>().damage = 1;
        }
        gun.GetComponent<Gun>().bulletSize = gunb.GetComponent<Gun>().bulletSize * (1 + (bangSize * itemCounts[4]));
        gun.GetComponent<Gun>().boomScale = gunb.GetComponent<Gun>().boomScale * (1 + (bangSize * itemCounts[4]));
        gun.GetComponent<Gun>().bulletForce = gunb.GetComponent<Gun>().bulletForce * (1 + (gunpowder * itemCounts[2])) * (1 + (highSpeed * itemCounts[3])) * (1 - (powerSpeed * itemCounts[12]));
        gun.GetComponent<Gun>().piecre = gunb.GetComponent<Gun>().piecre + itemCounts[2] + itemCounts[12];
        gun.GetComponent<Gun>().reloadSpeed = gunb.GetComponent<Gun>().reloadSpeed * (1 + (fullReload * itemCounts[5])) * (1 - (glove * itemCounts[16]));
        float temp = 1 - (fullAmmo * itemCounts[5]);
        if (temp < 0.3 && itemCounts[3] > 0) 
        {
            temp = 0.3f;
        }
        float temp2 = 1 - (highAmmo * itemCounts[3]);
        if (temp < 0.3 && itemCounts[5] > 0)
        {
            temp2 = 0.3f;
        }
        gun.GetComponent<Gun>().maxAmmo = Mathf.CeilToInt(gunb.GetComponent<Gun>().ammo * (1 + (lowAmmo * itemCounts[13])) * (temp * temp2));
        if (gun.GetComponent<Gun>().maxAmmo < 1)
        {
            gun.GetComponent<Gun>().maxAmmo = 1;
        }
        gun.GetComponent<Gun>().projectiles = gunb.GetComponent<Gun>().projectiles + itemCounts[5] + itemCounts[6];
        gun.GetComponent<Gun>().knockBack = gunb.GetComponent<Gun>().knockBack * (1 + (bell * itemCounts[24]));
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

        if (itemCounts[19] > 0)
        {
            gun.GetComponent<Gun>().burnOn = true;
            gun.GetComponent<Gun>().burnLvl = itemCounts[19];
        }

        if (itemCounts[20] > 0)
        {
            gun.GetComponent<Gun>().freezeOn = true;
            gun.GetComponent<Gun>().freezeLvl = itemCounts[20];
        }

        if (itemCounts[22] > 0)
        {
            if (beatG == null)
            {
                beatG = Instantiate(beats);

            }
            else
            {
                Destroy(beatG);
                beatG = Instantiate(beats);
            }
            beatG.GetComponent<BeatsManager>().player = player;
            beatG.GetComponent<BeatsManager>().beatsLvl = itemCounts[22];
        }

        if (itemCounts[25] > 0)
        {
            gun.GetComponent<Gun>().tridentOn = true;
            gun.GetComponent<Gun>().tridentLvl = itemCounts[25];
        }

        if (itemCounts[26] > 0)
        {
            gun.GetComponent<Gun>().laserOn = true;
            gun.GetComponent<Gun>().laserLvl = itemCounts[26];
        }

        if (itemCounts[27] > 0)
        {
            if (matrixG == null)
            {
                matrixG = Instantiate(matrix);

            }
            else
            {
                Destroy(matrixG);
                matrixG = Instantiate(matrix);
            }
            matrixG.GetComponent<Matrix>().player = player;
            matrixG.GetComponent<Matrix>().matrixLvl = itemCounts[27];
        }

    }

    public void itemUpgradePlayer() 
    {
        player.GetComponent<PlayerMovement>().moveSpeed = playerPref.GetComponent<PlayerMovement>().moveSpeed * (1 + (run * itemCounts[1]));
        player.GetComponent<PlayerMovement>().speedReduced = false;
        sis.GetComponent<Sister>().moveSpeed = sisPre.GetComponent<Sister>().moveSpeed * (1 + (leash * itemCounts[7]));
        player.GetComponent<PlayerMovement>().pickUpRadius = playerPref.GetComponent<PlayerMovement>().pickUpRadius * (1 + (mag * itemCounts[8]));
        sis.GetComponent<Sister>().pickUpRadius = sisPre.GetComponent<Sister>().pickUpRadius * (1 + (mag * itemCounts[8]));
        sis.GetComponent<Sister>().maxHealth = sisPre.GetComponent<Sister>().maxHealth - itemCounts[17];
        player.GetComponent<PlayerMovement>().speedReduction = player.GetComponent<PlayerMovement>().speedReduction * (1 + (bell * itemCounts[24]));
        if (sis.GetComponent<Sister>().health > sis.GetComponent<Sister>().maxHealth) 
        {
            sis.GetComponent<Sister>().health = sis.GetComponent<Sister>().maxHealth;
            sisH = sis.GetComponent<Sister>().maxHealth;
        }
        if (itemCounts[9] > 0)
        {
            if (snowG == null) 
            {
                snowG = Instantiate(snow, player.transform);
            }
            float snowScale = snow.transform.localScale.x * (1 + (snowRadius * itemCounts[9]));
            snowG.transform.localScale = new Vector3(snowScale, snowScale, snowScale);
            snowG.GetComponent<Snow>().speedMod = snow.GetComponent<Snow>().radius * (1 - (snowPower * itemCounts[9]));
        }

        if (itemCounts[10] > 0)
        {
            if (bubbleG == null)
            {
                bubbleG = Instantiate(bubble, player.transform);
                bubbleS = Instantiate(bubble, sis.transform);
            }
            bubbleS.GetComponent<Bubble>().bubbleLvl = itemCounts[10];
            bubbleG.GetComponent<Bubble>().bubbleLvl = itemCounts[10];
        }

        if (itemCounts[11] > 0)
        {
            if (missileG == null) 
            {
                missileG = Instantiate(missile, player.transform);
                missileG.GetComponent<MissileLauncher>().player = player;
            }
            missileG.GetComponent<MissileLauncher>().missileLvl = itemCounts[11];
        }

        if (itemCounts[18] > 0)
        {
            if (lightG == null)
            {
                lightG = Instantiate(lightHouse, sis.transform);
            }
            else
            {
                Destroy(lightG);
                lightG = Instantiate(lightHouse, sis.transform);
            }
            lightG.GetComponent<Lighthouse>().lightLvl = itemCounts[18];
        }

        if (itemCounts[21] > 0)
        {
            if (catG == null) 
            {
                catG = Instantiate(cat, player.transform.position, Quaternion.identity);
            }
            catG.GetComponent<Cat>().player = player;
            catG.GetComponent<Cat>().damage = cat.GetComponent<Cat>().damage + (5 * (itemCounts[21]-1));
            catG.GetComponent<Cat>().attackCD = cat.GetComponent<Cat>().attackCD * (1 - (0.1f * itemCounts[21]));
            catG.GetComponent<Cat>().moveSpeed = cat.GetComponent<Cat>().moveSpeed * (1 + (0.2f * itemCounts[21]));
        }

        if (itemCounts[22] > 0)
        {
            if (beatG == null)
            {
                beatG = Instantiate(beats);
               
            }
            else 
            {
                Destroy(beatG);
                beatG = Instantiate(beats);
            } 
            beatG.GetComponent<BeatsManager>().player = player;
            beatG.GetComponent<BeatsManager>().beatsLvl = itemCounts[22];
        }

        if (itemCounts[23] > 0)
        {
            player.GetComponent<PlayerMovement>().coinOn = true;
            player.GetComponent<PlayerMovement>().coinLvl = itemCounts[23];
        }

        if (itemCounts[27] > 0) 
        {
            if (matrixG == null)
            {
                matrixG = Instantiate(matrix);
                
            }
            else 
            {
                Destroy(matrixG);
                matrixG = Instantiate(matrix);
            }
            matrixG.GetComponent<Matrix>().player = player;
            matrixG.GetComponent<Matrix>().matrixLvl = itemCounts[27];
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
            case 9:
                SceneManager.LoadScene("Stage1Hard");
                break;
            case 10:
                SceneManager.LoadScene("Stage1Hell");
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

        if (scene.name == "Stage1" || scene.name == "Stage1Hard" || scene.name == "Stage1Hell" || scene.name == "Stage1Normal")
        {
            levelStart();
            currManager = Instantiate(stageManager[0]);
            currManager.GetComponent<stageManager>().gameM = this.gameObject;
            currManager.GetComponent<stageManager>().player = player;
            currManager.GetComponent<stageManager>().sister = sis;
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
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
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
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
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
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
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
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
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
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
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
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
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            currUI = Instantiate(UI);
            uiStart(currUI);
        }

        if (scene.name == "UpgradeShop")
        {
            Time.timeScale = 1;
            
            currManager = Instantiate(stageManager[7]);
            currUI = Instantiate(UI);
            upgradeStart();
            Camera.main.gameObject.transform.position = Vector2.zero;
            player.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
            uiStart(currUI);
            currManager.GetComponent<upgradeShopManager>().gameManager = this.gameObject;
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            currManager.GetComponentInChildren<upgradeShopManager>().UI = currUI;
            currManager.GetComponent<upgradeShopManager>().player = player;
            currManager.GetComponent<upgradeShopManager>().sister = sis;
        }

        if (scene.name == "UpgradeShopTest")
        {
            Time.timeScale = 1;

            currManager = Instantiate(stageManager[7]);
            currUI = Instantiate(UI);
            upgradeStart();
            Camera.main.gameObject.transform.position = Vector2.zero;
            player.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
            uiStart(currUI);
            currManager.GetComponent<upgradeShopManager>().gameManager = this.gameObject;
            currManager.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
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
        currUI.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        currUI.GetComponent<UIManager>().aniGun.speed = 1 / gun.GetComponent<Gun>().reloadSpeed;
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

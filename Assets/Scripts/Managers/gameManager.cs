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
    public int speedUp;
    public int fireUp;
    public int reloadUp;

    //level count
    public int levelNum = 1;

    //stageManagerPrefabs

    public GameObject s1MP;
    public GameObject s1;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
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
    }

    void levelEnd()
    {
        bank = player.GetComponent<PlayerMovement>().bank;
        playerH = player.GetComponent<PlayerMovement>().health;
        sisH = sis.GetComponent<Sister>().health;
        levelNum++;
    }

    void spawnWep(int num)
    {
        switch (num)
        {
            case 1:
                gun = Instantiate(rev, player.transform.position, player.transform.rotation);
                gun.GetComponent<Revolver>().player = player;
                gun.GetComponent<Revolver>().cam = player.GetComponent<PlayerMovement>().cam;
                break;

            case 2:
                gun = Instantiate(shotG, player.transform.position, player.transform.rotation);
                gun.GetComponent<Shotgun>().player = player;
                break;

            case 3:
                gun = Instantiate(machineG, player.transform.position, player.transform.rotation);
                gun.GetComponent<MachineGun>().player = player;
                break;

            case 4:
                gun = Instantiate(snipe, player.transform.position, player.transform.rotation);
                gun.GetComponent<Sniper>().player = player;
                break;
        }
    }

    void spawnLevel(int level)
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
            s1 = Instantiate(s1MP);
            s1.GetComponent<stage1Manager>().gameM = this.gameObject;
            s1.GetComponent<stage1Manager>().player = player;
        }
    }
}

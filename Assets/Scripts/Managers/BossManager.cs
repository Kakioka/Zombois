using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    //This script is on the StageManager game object
    private GameObject gameM;
    private gameManager gm;
    private stageManager sm;

    //boss prefs
    [SerializeField]
    private GameObject sisterBossPref, brotherBossPref;

    //bools controlling which boss is spawned
    [SerializeField]
    private bool spawnSis, spawnBro;

    //boss bar
    [SerializeField]
    public GameObject bossBar;

    //evil gun prefabs
    public List<GameObject> bGuns = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameM = GetComponent<stageManager>().gameM;
        gm = gameM.GetComponent<gameManager>();
        sm = GetComponent<stageManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spawnBro = true;
            SpawnBoss();
            spawnBro = false;
        }
    }

    public GameObject SpawnBoss()
    {
        if (spawnBro){
            GameObject temp = Instantiate(brotherBossPref);
            temp.GetComponent<Enemy>().player = sm.player;
            temp.GetComponent<Enemy>().health *= sm.hpMod;
            temp.GetComponent<Enemy>().sister = sm.player;

            bSpawnWep(gm.wepNum, temp);


            return temp;
        }
        else
        {
            GameObject boss = Instantiate(sisterBossPref, sm.transform.position, Quaternion.identity);
            gameM.GetComponent<gameManager>().currUI.GetComponent<UIManager>().sisH.SetActive(false); //turns off the sister health
            sm.sister.SetActive(false); //set sister (good) off
            boss.GetComponent<sisBoss>().player = sm.player; //set the refernece
            boss.GetComponent<Enemy>().player = sm.player; //set reference
            boss.GetComponent<Enemy>().sister = sm.player; //set refernece
            boss.GetComponent<Enemy>().health *= sm.hpMod; //increase health mod
            return boss;
        }
    }

    public void bSpawnWep(int num, GameObject bro)
    {
        GameObject bGun = Instantiate(bGuns[num], bro.transform.position, Quaternion.identity);
        bGun.GetComponent<BrotherBossGun>().player = sm.player;
        bro.GetComponent<BrotherBoss>().gun = bGun;
    }
}

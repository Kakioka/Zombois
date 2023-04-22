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
            sm.boss = temp;
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
        //spawn the gun that the player currently has equipped
        GameObject bGun = Instantiate(bGuns[num], bro.transform.position, Quaternion.identity);
        //set all it's values
        bGun.GetComponent<BrotherBossGun>().player = sm.boss;
        bGun.GetComponent<BrotherBossGun>().sister = sm.sister;
        bGun.GetComponent<BrotherBossGun>().target = sm.player;
        //upgrade the gun to match the player's
        bItemUpgradeGun(bGun, gm.gun);
        //set the boss's gun to be the newly spawned gun
        bro.GetComponent<BrotherBoss>().gun = bGun;
    }

    //pass in the spawned weapon as gun, then pass in the player's current weapon as gunb. gun will then match gunb aside from reload speed, ammo, and beats item
    //also doesn't account for perks
    //didn't really get the matrix thing so i deleted it
    //no bell cus it's protected
    public void bItemUpgradeGun(GameObject gun, GameObject gunb)
    {
        gun.GetComponent<BrotherBossGun>().fireRate = gunb.GetComponent<Gun>().fireRate * ((1 - (gm.stim * gm.itemCounts[0])) * (1 + (gm.bangFire * gm.itemCounts[4])));
        gun.GetComponent<BrotherBossGun>().damage = Mathf.CeilToInt(gunb.GetComponent<Gun>().damage * Mathf.Pow(2, gm.itemCounts[17]) * (1 + (gm.bangDmg * gm.itemCounts[4]) + (gm.highDmg * gm.itemCounts[3]) + (gm.powerDmg * gm.itemCounts[12])) * (1 - (gm.MultiDmg * gm.itemCounts[6]) - (gm.lowDmg * gm.itemCounts[13])));

        if (gun.GetComponent<BrotherBossGun>().damage <= 0)
        {
            gun.GetComponent<BrotherBossGun>().damage = 1;
        }

        gun.GetComponent<BrotherBossGun>().bulletSize = gunb.GetComponent<Gun>().bulletSize * (1 + (gm.bangSize * gm.itemCounts[4]));
        gun.GetComponent<BrotherBossGun>().boomScale = gunb.GetComponent<Gun>().boomScale * (1 + (gm.bangSize * gm.itemCounts[4]));
        gun.GetComponent<BrotherBossGun>().bulletForce = gunb.GetComponent<Gun>().bulletForce * (1 + (gm.gunpowder * gm.itemCounts[2])) * (1 + (gm.highSpeed * gm.itemCounts[3])) * (1 - (gm.powerSpeed * gm.itemCounts[12]));
        gun.GetComponent<BrotherBossGun>().piecre = gunb.GetComponent<Gun>().piecre + gm.itemCounts[2] + gm.itemCounts[12];

        gun.GetComponent<BrotherBossGun>().projectiles = gunb.GetComponent<Gun>().projectiles + gm.itemCounts[5] + gm.itemCounts[6];
        if (gm.itemCounts[14] > 0)
        {
            gun.GetComponent<BrotherBossGun>().bleedOn = true;
            gun.GetComponent<BrotherBossGun>().bleedLvl = gm.itemCounts[14];
        }

        if (gm.itemCounts[15] > 0)
        {
            gun.GetComponent<BrotherBossGun>().splinterOn = true;
            gun.GetComponent<BrotherBossGun>().splintLvl = gm.itemCounts[15];
        }

        if (gm.itemCounts[19] > 0)
        {
            gun.GetComponent<BrotherBossGun>().burnOn = true;
            gun.GetComponent<BrotherBossGun>().burnLvl = gm.itemCounts[19];
        }

        if (gm.itemCounts[20] > 0)
        {
            gun.GetComponent<BrotherBossGun>().freezeOn = true;
            gun.GetComponent<BrotherBossGun>().freezeLvl = gm.itemCounts[20];
        }

        if (gm.itemCounts[25] > 0)
        {
            gun.GetComponent<BrotherBossGun>().tridentOn = true;
            gun.GetComponent<BrotherBossGun>().tridentDamage = 5 * gm.itemCounts[25];
        }

        if (gm.itemCounts[26] > 0)
        {
            gun.GetComponent<BrotherBossGun>().laserOn = true;
            gun.GetComponent<BrotherBossGun>().laserDamage = 5 * gm.itemCounts[26];
        }
    }
}

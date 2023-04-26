using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
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
    private int whichBoss;

    //boss bar
    [SerializeField]
    public GameObject bossBar;

    //evil gun prefabs
    public List<GameObject> bGuns = new List<GameObject>();

    //shotty exception
    private bool shotty = false;

    // Start is called before the first frame update
    void Start()
    {
        gameM = GetComponent<stageManager>().gameM;
        gm = gameM.GetComponent<gameManager>();
        sm = GetComponent<stageManager>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SpawnBoss();
        }*/
    }

    public GameObject SpawnBoss()
    {
        //min is inclusive, max is exclusive. This will be a range between 0 and 1 but ints so either 0 or 1.
        whichBoss = Random.Range(0, 2);
        if (whichBoss == 1){
            GameObject temp = Instantiate(brotherBossPref);
            sm.boss = temp;
            temp.GetComponent<Enemy>().player = sm.player;
            temp.GetComponent<Enemy>().health *= sm.hpMod;
            temp.GetComponent<Enemy>().sister = sm.player;
            gameM.GetComponent<gameManager>().currUI.GetComponent<UIManager>().sisH.SetActive(false); //turns off the sister health
            //sm.sister.SetActive(false); //set sister (good) off
            bSpawnWep(gm.wepNum, temp);

            return temp;
        }
        else if (whichBoss == 0)
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
        else
        {
            return null;
        }
    }

    public GameObject SpawnBossEndless()
    {
        //min is inclusive, max is exclusive. This will be a range between 0 and 1 but ints so either 0 or 1.
        whichBoss = Random.Range(0, 2);
        if (whichBoss == 1)
        {
            Vector3 temp2 = (Random.insideUnitCircle.normalized * 10) + new Vector2(gm.player.transform.position.x, gm.player.transform.position.y);
            GameObject temp = Instantiate(brotherBossPref,temp2, Quaternion.identity);
            sm.boss = temp;
            temp.GetComponent<Enemy>().player = sm.player;
            temp.GetComponent<Enemy>().health *= sm.hpMod;
            temp.GetComponent<Enemy>().sister = sm.player;
            //gameM.GetComponent<gameManager>().currUI.GetComponent<UIManager>().sisH.SetActive(false); //turns off the sister health
            //sm.sister.SetActive(false); //set sister (good) off
            bSpawnWep(gm.wepNum, temp);

            return temp;
        }
        else if (whichBoss == 0)
        {
            Vector3 temp2 = (Random.insideUnitCircle.normalized * 10) + new Vector2(gm.player.transform.position.x, gm.player.transform.position.y);
            GameObject boss = Instantiate(sisterBossPref, temp2, Quaternion.identity);
            //gameM.GetComponent<gameManager>().currUI.GetComponent<UIManager>().sisH.SetActive(false); //turns off the sister health
            //sm.sister.SetActive(false); //set sister (good) off
            boss.GetComponent<sisBoss>().player = sm.player; //set the refernece
            boss.GetComponent<Enemy>().player = sm.player; //set reference
            boss.GetComponent<Enemy>().sister = sm.player; //set refernece
            boss.GetComponent<Enemy>().health *= sm.hpMod; //increase health mod
            return boss;
        }
        else
        {
            return null;
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
        if (num == 5)
        {
            bGun.GetComponent<BDualPistols>().bb = bro.GetComponent<BrotherBoss>();
        }
        if (num == 1)
        {
            shotty = true;
        }
        //upgrade the gun to match the player's
        bItemUpgradeGun(bGun, gm.gun);
        //set the boss's gun to be the newly spawned gun
        bro.GetComponent<BrotherBoss>().gun = bGun;
        //if the dual pistols were spawned, set the main dual pistol's bb reference to brother boss attatched to the main dude

    }

    //pass in the spawned weapon as gun, then pass in the player's current weapon as gunb. gun will then match gunb aside from reload speed, ammo, and beats item
    //also doesn't account for perks
    //didn't really get the matrix thing so i deleted it
    //no bell cus it's protected
    public void bItemUpgradeGun(GameObject gun, GameObject gunb)
    {
        //exception firerate change for shotgun
        if (!shotty)
        {
            gun.GetComponent<BrotherBossGun>().fireRate = gunb.GetComponent<Gun>().fireRate * ((1 - (gm.stim * gm.itemCounts[0])) * (1 + (gm.bangFire * gm.itemCounts[4])));
        }
        else
        {
            gun.GetComponent<BrotherBossGun>().fireRate = 3;
        }
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

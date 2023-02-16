using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    public int playerH;

    //sister
    public GameObject sisPre;
    public GameObject sis;
    public int sisH;

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

    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

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
        spawnLevel(levelNum);
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
    }

    void spawnLevel(int num)
    {
        switch (num)
        {
            case 1:
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
        }
    }
}

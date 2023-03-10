using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class stageManager : MonoBehaviour
{
    public int maxSpawns;
    public int currSpawns;

    public GameObject gameM;
    public GameObject player;
    public GameObject sister;
    public GameObject spawner;
    public GameObject levelDone;

    public int enemyLeft;
    public TextMeshProUGUI enemyLeftText;
    public GameObject enemyLeftObj;

    public float hpMod;

    public int stageCount;
    public TextMeshProUGUI stageCountText;
    public GameObject stageEnd;

    public float spawnSpeed = 3;
    public float spawnSpeedMod = 1;
    public int spawnMulti;

    public GameObject sisDied;
    public GameObject playerDied;
    public GameObject death;
    public TextMeshProUGUI survived;

    public GameObject bossPre;
    public GameObject bossBar;

    private int tempCurr;

    private bool bossSpawned = false;

    public GameObject boss;

    public float timer;

    private IEnumerator end() 
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0;
        levelDone.SetActive(true);

    }

    // Start is called before the first frame update
    void Start()
    {
        enemyLeft = maxSpawns;
        spawner.GetComponent<Spawner>().player = player;
        spawner.GetComponent<Spawner>().sister = sister;
        spawner.GetComponent<Spawner>().target = player;
        spawner.GetComponent<Spawner>().hpMod = hpMod;
        spawner.GetComponent<Spawner>().time = spawnSpeed * spawnSpeedMod;
        enemyLeftText.text = enemyLeft.ToString();
        stageCountText.text = "Day " + stageCount;
    }

    // Update is called once per frame
    void Update()
    {
        currSpawns = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (currSpawns < tempCurr)
        {
            tempCurr--;
            enemyLeft--;
            enemyLeftText.text = enemyLeft.ToString();
        }
        if (currSpawns == 0 && maxSpawns == 0)
        {
            if (stageCount == 7 && bossSpawned == false)
            {
                stageEnd.SetActive(true);
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                    stageEnd.GetComponent<TextMeshProUGUI>().text = "Stage ends in: " + Mathf.Round(timer * 100f) / 100f;
                }
                else
                {
                    gameM.GetComponent<gameManager>().currUI.GetComponent<UIManager>().sisH.SetActive(false);
                    stageEnd.SetActive(false);
                    bossSpawned = true;
                    spawner.SetActive(false);
                    boss = Instantiate(bossPre, sister.transform.position, Quaternion.identity);
                    sister.SetActive(false);
                    boss.GetComponent<sisBoss>().player = player;
                    boss.GetComponent<Enemy>().player = player;
                    boss.GetComponent<Enemy>().sister = player;
                    enemyLeftObj.SetActive(false);
                    enemyLeftText.gameObject.SetActive(false);
                    bossBar.SetActive(true);
                    bossBar.GetComponent<BossHpBar>().boss = boss;
                    bossBar.GetComponent<BossHpBar>().enabled = true;
                }
            }
            else if(stageCount != 7)
            {
                stageEnd.SetActive(true);
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                    stageEnd.GetComponent<TextMeshProUGUI>().text = "Stage ends in: " + Mathf.Round(timer * 100f)/100f;
                }
                else 
                {
                    stageEnd.GetComponent<TextMeshProUGUI>().text = "Stage ends in: 0.00";
                    Time.timeScale = 0;
                    levelDone.SetActive(true);
                }  
            }
        }
        else if (maxSpawns == 0)
        {
            spawner.SetActive(false);
        }
        else if (spawner.GetComponent<Spawner>().coolDown == false)
        {
            maxSpawns--;
            tempCurr++;
            StartCoroutine(spawner.GetComponent<Spawner>().spawnRandom());
        }

        if (player.GetComponent<PlayerMovement>().health <= 0 || sister.GetComponent<Sister>().health <= 0)
        {
            Time.timeScale = 0;
            death.SetActive(true);
            survived.text = "You surivived " + stageCount + " days";
            if (player.GetComponent<PlayerMovement>().health <= 0)
            {
                playerDied.SetActive(true);
            }
            else 
            {
                sisDied.SetActive(true);
            }
        }
        
        if (bossSpawned == true) 
        {
            if (boss == null) 
            {
                bossBar.SetActive(false);
                StartCoroutine(end());
            }
        }
    }

    public void next()
    {
        Time.timeScale = 1;
        gameM.GetComponent<gameManager>().levelEnd();
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}
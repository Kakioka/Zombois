using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageManager : MonoBehaviour
{

    public GameObject gameM;
    public GameObject player;
    public GameObject sister;
    public GameObject spawner;
    public GameObject levelDone;

    public TextMeshProUGUI enemyLeftText;
    public GameObject enemyLeftObj;

    public float hpMod;
    public float speedMod;

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

    [SerializeField]
    private GameObject bossPre;
    public GameObject bossBar;

    private int tempCurr;

    public bool bossSpawned = false;

    public GameObject boss;

    [SerializeField]
    private bool bossDead = false;

    [SerializeField]
    private float timer;

    [SerializeField]
    private float stageTimer;

    private bool stageEnded = false;

    private float endSpeed;
    private float endHpMod;
    private float endSpeedMod;
    private bool dropCheck;

    [SerializeField]
    private List<GameObject> drops = new List<GameObject>();

    private IEnumerator end()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0;
        levelDone.SetActive(true);
    }

    private IEnumerator spawnDrop()
    {
        dropCheck = true;
        yield return new WaitForSeconds(30f);
        Vector3 pos = (Random.insideUnitCircle.normalized * 10f) + new Vector2(player.transform.position.x, player.transform.position.y);
        GameObject temp = Instantiate(drops[Random.Range(0,drops.Count)], pos, Quaternion.identity);
        temp.GetComponent<Coin>().player = player;
        temp.GetComponent<Coin>().sister = sister;
        dropCheck = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner.GetComponent<Spawner>().player = player;
        spawner.GetComponent<Spawner>().sister = sister;
        spawner.GetComponent<Spawner>().target = player;
        endHpMod = hpMod;
        endSpeed = spawnSpeed * spawnSpeedMod;
        endSpeedMod = speedMod;
        stageCountText.text = "Day " + stageCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (stageTimer >= 0)//if stage is not over 
        {
            stageTimer -= Time.deltaTime;
            spawner.GetComponent<Spawner>().time = endSpeed * (1 + (0.001f * stageTimer * 3f));
            spawner.GetComponent<Spawner>().hpMod = endHpMod * (1 - (0.001f * stageTimer * 3f));
            spawner.GetComponent<Spawner>().speedMod = endSpeedMod * (1 - (0.001f * stageTimer * 3f));
            enemyLeftText.text = Mathf.RoundToInt(stageTimer).ToString();
        }

        if (!dropCheck) //mid stage pick ups
        {
            StartCoroutine(spawnDrop());
        }
       
        if(stageTimer <= 0)
        {
            spawner.SetActive(false); //turn spawner off
            if (!stageEnded) //exceute once
            {
                stageEnded = true; //check if does once
                foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy")) //nuke enemies
                {
                    e.GetComponent<Enemy>().health = 0;
                }

                foreach (GameObject b in GameObject.FindGameObjectsWithTag("enemyBullet")) //nuke spitter bullets
                {
                    Destroy(b);
                }
            }

            if (stageCount == 7 && bossSpawned == false) // if stage 7 && if we have not spawned boss
            {
                stageEnd.SetActive(true); // false ending
                if (timer > 0) //timer for 5 seconds
                {
                    timer -= Time.deltaTime;
                    stageEnd.GetComponent<TextMeshProUGUI>().text = "Stage ends in: " + Mathf.Round(timer * 100f) / 100f;
                }
                else // if timer for 5 seocnds is over spawn boss
                {
                    boss = GetComponent<BossManager>().SpawnBoss();
                    bossSpawned = true; // boss is spawned 

                    bossBar.SetActive(true); //health bar on
                    bossBar.GetComponent<BossHpBar>().boss = boss; //refernece for health bar
                    bossBar.GetComponent<BossHpBar>().enabled = true; //turn on the script on
                    stageEnd.SetActive(false);
                }
            }
            else if (stageCount != 7) //not spawn boss != 7
            {
                stageEnd.SetActive(true);
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                    stageEnd.GetComponent<TextMeshProUGUI>().text = "Stage ends in: " + Mathf.Round(timer * 100f) / 100f;
                }
                else
                {
                    stageEnd.GetComponent<TextMeshProUGUI>().text = "Stage ends in: 0.00";
                    Time.timeScale = 0;
                    levelDone.SetActive(true);
                }
            }
        }
        else if (spawner.GetComponent<Spawner>().coolDown == false) //spawning enmies with spawner 
        {
            StartCoroutine(spawner.GetComponent<Spawner>().spawnRandom());
        }

        if (player.GetComponent<PlayerMovement>().health <= 0 || sister.GetComponent<Sister>().health <= 0) //death player
        {
            Time.timeScale = 0;
            death.SetActive(true);
            survived.text = "You survived " + stageCount + " days";
            if (player.GetComponent<PlayerMovement>().health <= 0)
            {
                playerDied.SetActive(true);
            }
            else
            {
                sisDied.SetActive(true);
            }
        }

        if (bossSpawned == true) //turns off the boss bar
        {
            if (boss == null)
            {
                bossBar.SetActive(false);
                bossDead = true;
                StartCoroutine(end());
            }
        }
    }

    public void next() //button
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
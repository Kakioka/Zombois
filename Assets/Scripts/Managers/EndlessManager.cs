using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessManager : MonoBehaviour
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

    public bool bossSpawned = false;

    public GameObject boss;

    [SerializeField]
    private float timer;

    [SerializeField]
    private float stageTimer;

    private float startSpeed;
    private float startHpMod;
    private float startSpeedMod;
    private bool dropCheck;

    [SerializeField]
    private List<GameObject> drops = new List<GameObject>();

    [SerializeField]
    private int currExperience;
    [SerializeField]
    private int experienceCap;
    [SerializeField]
    private TextMeshProUGUI experienceCount;
    [SerializeField]
    private Slider experienceFill;
    [SerializeField]
    private GameObject levelUp;

    private IEnumerator spawnDrop()
    {
        dropCheck = true;
        yield return new WaitForSeconds(30f);
        Vector3 pos = (Random.insideUnitCircle.normalized * 10f) + new Vector2(player.transform.position.x, player.transform.position.y);
        GameObject temp = Instantiate(drops[Random.Range(0, drops.Count)], pos, Quaternion.identity);
        temp.GetComponent<Coin>().player = player;
        temp.GetComponent<Coin>().sister = sister;
        dropCheck = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelUp.GetComponent<LevelUpChoice>().gameM = gameM;
        spawner.GetComponent<Spawner>().player = player;
        spawner.GetComponent<Spawner>().sister = sister;
        spawner.GetComponent<Spawner>().target = player;
        startSpeed = spawnSpeed;
        startHpMod = hpMod;
        startSpeedMod = speedMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().bank >= experienceCap)
        {
            player.GetComponent<PlayerMovement>().bank -= experienceCap;
            experienceCap = Mathf.CeilToInt(experienceCap * 1.5f);
            levelUp.GetComponent<LevelUpChoice>().levelUp();
        }

        experienceCount.text = "Exp: " + player.GetComponent<PlayerMovement>().bank + "/" + experienceCap;
        experienceFill.value = (player.GetComponent<PlayerMovement>().bank * 100.0f) / (experienceCap * 100.0f);

        stageTimer += Time.deltaTime;
        float temp = 0.1f * stageTimer;
        spawner.GetComponent<Spawner>().time = startSpeed * (1 - (0.001f * stageTimer * 3f));
        spawner.GetComponent<Spawner>().hpMod = startHpMod * (1 + (0.001f * stageTimer * 3f));
        spawner.GetComponent<Spawner>().speedMod = startSpeedMod * (1 + (0.001f * stageTimer * 3f));
        enemyLeftText.text = Mathf.RoundToInt(stageTimer).ToString();

        if (!dropCheck)
        {
            StartCoroutine(spawnDrop());
        }

        if (player.GetComponent<PlayerMovement>().health <= 0 || sister.GetComponent<Sister>().health <= 0)
        {
            Time.timeScale = 0;
            death.SetActive(true);
            survived.text = "You survived for " +  stageTimer;
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
            }
        }


        if (stageTimer % 500 == 0)
        {
            Vector3 temp2 = (Random.insideUnitCircle.normalized * 10) + new Vector2(player.transform.position.x, player.transform.position.y);
            bossSpawned = true;
            boss = GetComponent<BossManager>().SpawnBoss();
            bossBar.SetActive(true);
            bossBar.GetComponent<BossHpBar>().boss = boss;
            bossBar.GetComponent<BossHpBar>().enabled = true;
        }

        if (bossSpawned == true) //turns off the boss bar
        {
            if (boss == null)
            {
                bossSpawned = false;
                bossBar.SetActive(false);
            }
        }

        if (stageTimer < 60f)
        {
            if (spawner.GetComponent<Spawner>().coolDown == false)
            {
                StartCoroutine(spawner.GetComponent<Spawner>().spawnNum(1));
            }
        }
        else if(stageTimer < 120f)
        {
            if (spawner.GetComponent<Spawner>().coolDown == false)
            {
                StartCoroutine(spawner.GetComponent<Spawner>().spawnRandomRange(1,2));
            }
        }
        else if (stageTimer < 180f)
        {
            if (spawner.GetComponent<Spawner>().coolDown == false)
            {
                StartCoroutine(spawner.GetComponent<Spawner>().spawnRandomRange(1, 3));
            }
        }
        else if (stageTimer < 240f)
        {
            if (spawner.GetComponent<Spawner>().coolDown == false)
            {
                StartCoroutine(spawner.GetComponent<Spawner>().spawnRandomRange(1, 4));
            }
        }
        else if (stageTimer < 300f)
        {
            if (spawner.GetComponent<Spawner>().coolDown == false)
            {
                StartCoroutine(spawner.GetComponent<Spawner>().spawnRandomRange(1, 5));
            }
        }
        else if (stageTimer < 300f)
        {
            if (spawner.GetComponent<Spawner>().coolDown == false)
            {
                StartCoroutine(spawner.GetComponent<Spawner>().spawnRandomRange(1, 6));
            }
        }
        else
        {
            if (spawner.GetComponent<Spawner>().coolDown == false)
            {
                StartCoroutine(spawner.GetComponent<Spawner>().spawnRandom());
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

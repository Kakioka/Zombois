using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class stageManager : MonoBehaviour
{
    public int maxSpawns;
    public int currSpawns;
    public GameObject gameM;
    public GameObject gameMPre;
    public GameObject player;
    public GameObject sister;
    public GameObject spawner;
    public GameObject levelDone;
    public int enemyLeft;
    public TextMeshProUGUI enemyLeftText;
    public float hpMod;
    public int stageCount;
    public TextMeshProUGUI stageCountText;
    public float spawnSpeed = 3;
    public float spawnSpeedMod = 1;

    public GameObject sisDied;
    public GameObject playerDied;
    public GameObject death;
    public TextMeshProUGUI survived;

    private int tempCurr;

    private IEnumerator end()
    {
        yield return new WaitForSeconds(3f);
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
            StartCoroutine(end());
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
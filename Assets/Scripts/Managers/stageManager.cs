using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public float hpMod;
    public int stageCount;
    public TextMeshProUGUI stageCountText;

    private int tempCurr;


    private IEnumerator end()
    {
        yield return new WaitForSeconds(3f);
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
    }

    public void next()
    {
        gameM.GetComponent<gameManager>().levelEnd();
    }
}
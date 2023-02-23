using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class stage1Manager : MonoBehaviour
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
        enemyLeftText.text = enemyLeft.ToString();
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
            StartCoroutine(spawner.GetComponent<Spawner>().spawnRandom(1,5));
        }
    }

    public void next()
    {
        gameM.GetComponent<gameManager>().levelEnd();
    }
}

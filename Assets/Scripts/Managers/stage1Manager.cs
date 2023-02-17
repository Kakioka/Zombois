using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1Manager : MonoBehaviour
{
    public int maxSpawns;
    public int currSpawns;
    public GameObject gameM;
    public GameObject player;
    public GameObject spawner;
    public GameObject levelDone;


    private IEnumerator end()
    {
        yield return new WaitForSeconds(3f);
        levelDone.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        currSpawns = maxSpawns;
        spawner.GetComponent<Spawner>().player = player;
    }

    // Update is called once per frame
    void Update()
    {
        currSpawns = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
            StartCoroutine(spawner.GetComponent<Spawner>().spawnRandom(1, 4));
        }
    }

    public void next()
    {
        gameM.GetComponent<gameManager>().levelEnd();
    }
}

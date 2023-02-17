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

    // Start is called before the first frame update
    void Start()
    {
        currSpawns = maxSpawns;
        spawner.GetComponent<Spawner>().player = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (currSpawns == 0)
        {
            spawner.SetActive(false);

        }
        else if(spawner.GetComponent<Spawner>().coolDown == false)
        {
            currSpawns--;
            StartCoroutine(spawner.GetComponent<Spawner>().spawnRandom(1, 4));
        }
    }
}

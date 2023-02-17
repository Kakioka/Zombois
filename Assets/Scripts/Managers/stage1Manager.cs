using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1Manager : MonoBehaviour
{
    public int maxSpawns;
    public int currSpawns;
    public GameObject gameM;
    public GameObject player;
    public GameObject spawnerP;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = Instantiate(spawnerP);
        spawner.GetComponent<Spawner>().player = player;
        spawner.GetComponent<Spawner>().spawerM = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (currSpawns == 0)
        {
            spawner.SetActive(false);
        }
    }
}

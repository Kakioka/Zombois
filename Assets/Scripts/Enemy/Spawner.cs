using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject basic;
    public GameObject spitter;
    public GameObject boomer;
    public GameObject zoomer;
    public float random;
    public float time;
    public bool coolDown = false;
    public int num = 1;
    public float radius = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator spawnRandom(int lower, int upper)
    {
        coolDown = true;
        random = Random.Range(lower, upper);
        Debug.Log(random);
        helperSpawn(random);
        yield return new WaitForSeconds(time);
        coolDown = false;
    }

    public IEnumerator spawnNum(int num)
    { 
        coolDown = true;
        helperSpawn(num);
        yield return new WaitForSeconds(time);
        coolDown = false;
    }

    void helperSpawn(float num) 
    {
        switch (num) 
        {
            case 1:
                GameObject b =  Instantiate(basic, Random.insideUnitCircle.normalized * radius, Quaternion.identity);
                b.GetComponent<Enemy>().player = player;
                break;
            case 2:
                GameObject s = Instantiate(spitter, Random.insideUnitCircle.normalized * radius, Quaternion.identity);
                s.GetComponent<Enemy>().player = player;
                break;
            case 3:
                GameObject z = Instantiate(zoomer, Random.insideUnitCircle.normalized * radius, Quaternion.identity);
                z.GetComponent<Enemy>().player = player;
                break;
            case 4:
                GameObject bo = Instantiate(boomer, Random.insideUnitCircle.normalized * radius, Quaternion.identity);
                bo.GetComponent<Enemy>().player = player;
                break;
        }
    }
}
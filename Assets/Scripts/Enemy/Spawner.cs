using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject basic;
    public GameObject spitter;
    public GameObject boomer;
    public GameObject zoomer;
    public float random;
    public float time;
    public bool randomize = false;
    public bool coolDown = false;
    public int num = 1;
    public bool spawnNums = true;
    public float radius = 1;
    public GameObject spawerM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (randomize) 
        {
            if (coolDown == false) 
            {
                StartCoroutine(spawnRandom());
            }
        }
        if (spawnNums) 
        {
            if (coolDown == false) 
            {
                StartCoroutine(spawnNum(num));
            }
        }

    }

    IEnumerator spawnRandom() 
    {
        coolDown = true; 
        random = Random.Range(1,4);
        helperSpawn(random);
        yield return new WaitForSeconds(time);
        coolDown = false;
    }

    IEnumerator spawnNum(int num)
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
                GameObject s = Instantiate(spitter, transform.position, Quaternion.identity);
                s.GetComponent<Enemy>().player = player;
                break;
            case 3:
                GameObject z = Instantiate(zoomer, transform.position, Quaternion.identity);
                z.GetComponent<Enemy>().player = player;
                break;
            case 4:
                GameObject bo = Instantiate(boomer, transform.position, Quaternion.identity);
                bo.GetComponent<Enemy>().player = player;
                break;
        }
    }

    public void randomLocation()
    {
        GameObject b = Instantiate(basic, Random.insideUnitCircle.normalized * radius, Quaternion.identity); 
    }
}
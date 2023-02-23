using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject sister;
    public GameObject target;
    public GameObject basic;
    public GameObject spitter;
    public GameObject boomer;
    public GameObject zoomer;
    public GameObject screamer;
    public GameObject knock;
    public GameObject beef;
    public float random;
    public float time;
    public bool coolDown = false;
    public int num = 1;
    public float radius = 1;

    public bool testN;
    public bool testR;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (testR == true && coolDown == false) 
        {
            StartCoroutine(spawnRandom(1, 8));
        }
        if (testN == true && coolDown == false)
        {
            StartCoroutine(spawnNum(num));
        }
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
        Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(target.transform.position.x, target.transform.position.y);
        switch (num) 
        {
            case 1:
                GameObject b =  Instantiate(basic, temp, Quaternion.identity);
                b.GetComponent<Enemy>().player = player;
                b.GetComponent<Enemy>().sister = sister;
                break;
            case 2:
                GameObject s = Instantiate(spitter, temp, Quaternion.identity);
                s.GetComponent<Enemy>().player = player;
                s.GetComponent<Enemy>().sister = sister;
                break;
            case 3:
                GameObject z = Instantiate(zoomer, temp, Quaternion.identity);
                z.GetComponent<Enemy>().player = player;
                z.GetComponent<Enemy>().sister = sister;
                break;
            case 4:
                GameObject bo = Instantiate(boomer, temp, Quaternion.identity);
                bo.GetComponent<Enemy>().player = player;
                bo.GetComponent<Enemy>().sister = sister;
                break;
            case 5:
                GameObject scre = Instantiate(screamer, temp, Quaternion.identity);
                scre.GetComponent<Enemy>().player = player;
                scre.GetComponent<Enemy>().sister = sister;
                scre.GetComponent<Enemy>().spawner = gameObject;
                break;
            case 6:
                GameObject be = Instantiate(beef, temp, Quaternion.identity);
                be.GetComponent<Enemy>().player = player;
                be.GetComponent<Enemy>().sister = sister;
                break;
            case 7:
                GameObject k = Instantiate(beef, temp, Quaternion.identity);
                k.GetComponent<Enemy>().player = player;
                k.GetComponent<Enemy>().sister = sister;
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float time;
    public bool coolDown = false;
    public int num = 1;
    public float radius = 1;
    public float hpMod;
    public List<int> nums = new List<int>();
    public float speedMod;
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
            StartCoroutine(spawnRandom());
        }
        if (testN == true && coolDown == false)
        {
            StartCoroutine(spawnNum(num));
        }
    }

    public IEnumerator spawnNumAtOnceType(int num, int type)
    {
        coolDown = true;
        for (int i = 0; i < num; i++)
        {
            helperSpawn(type);
        }
        yield return new WaitForSeconds(time);
        coolDown = false;
    }

    public IEnumerator spawnNumAtOnceSame(int num)
    {
        coolDown = true;
        int temp = nums[Random.Range(0, nums.Count)];
        for (int i = 0; i < num; i++)
        {
            helperSpawn(temp);
        }
        yield return new WaitForSeconds(time);
        coolDown = false;
    }

    public IEnumerator spawnNumAtOnceRandom(int num)
    {
        coolDown = true;
        for (int i = 0; i < num; i++)
        {
            helperSpawn(nums[Random.Range(0, nums.Count)]);
        }
        yield return new WaitForSeconds(time);
        coolDown = false;
    }

    public IEnumerator spawnRandom()
    {
        coolDown = true;
        helperSpawn(nums[Random.Range(0, nums.Count)]);
        yield return new WaitForSeconds(time);
        coolDown = false;
    }

    public IEnumerator spawnRandomRange(int lower, int upper)
    {
        coolDown = true;
        helperSpawn(nums[Random.Range(lower, upper)]);
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
                GameObject b = Instantiate(basic, temp, Quaternion.identity);
                b.GetComponent<Enemy>().player = player;
                b.GetComponent<Enemy>().sister = sister;
                b.GetComponent<Enemy>().health = Mathf.Ceil(b.GetComponent<Enemy>().health *= hpMod);
                b.GetComponent<Enemy>().moveSpeed *= speedMod;
                break;
            case 2:
                GameObject s = Instantiate(spitter, temp, Quaternion.identity);
                s.GetComponent<Enemy>().player = player;
                s.GetComponent<Enemy>().sister = sister;
                s.GetComponent<Enemy>().health = Mathf.Ceil(s.GetComponent<Enemy>().health *= hpMod);
                s.GetComponent<Enemy>().moveSpeed *= speedMod;
                break;
            case 3:
                GameObject z = Instantiate(zoomer, temp, Quaternion.identity);
                z.GetComponent<Enemy>().player = player;
                z.GetComponent<Enemy>().sister = sister;
                z.GetComponent<Enemy>().health = Mathf.Ceil(z.GetComponent<Enemy>().health *= hpMod);
                z.GetComponent<Enemy>().moveSpeed *= speedMod;
                break;
            case 4:
                GameObject bo = Instantiate(boomer, temp, Quaternion.identity);
                bo.GetComponent<Enemy>().player = player;
                bo.GetComponent<Enemy>().sister = sister;
                bo.GetComponent<Enemy>().health = Mathf.Ceil(bo.GetComponent<Enemy>().health *= hpMod);
                bo.GetComponent<Enemy>().moveSpeed *= speedMod;
                break;
            case 5:
                GameObject scre = Instantiate(screamer, temp, Quaternion.identity);
                scre.GetComponent<Enemy>().player = player;
                scre.GetComponent<Enemy>().sister = sister;
                scre.GetComponent<Enemy>().health = Mathf.Ceil(scre.GetComponent<Enemy>().health *= hpMod);
                scre.GetComponent<Enemy>().moveSpeed *= speedMod;
                break;
            case 6:
                GameObject be = Instantiate(beef, temp, Quaternion.identity);
                be.GetComponent<Enemy>().player = player;
                be.GetComponent<Enemy>().sister = sister;
                be.GetComponent<Enemy>().health = Mathf.Ceil(be.GetComponent<Enemy>().health *= hpMod);
                be.GetComponent<Enemy>().moveSpeed *= speedMod;
                break;
            case 7:
                GameObject k = Instantiate(knock, temp, Quaternion.identity);
                k.GetComponent<Enemy>().player = player;
                k.GetComponent<Enemy>().sister = sister;
                k.GetComponent<Enemy>().health = Mathf.Ceil(k.GetComponent<Enemy>().health *= hpMod);
                k.GetComponent<Enemy>().moveSpeed *= speedMod;
                break;
        }
    }
}
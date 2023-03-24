using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{

    public float fireRate;
    public int damage;
    public float speed;
    public float rotateSpeed;
    public bool coolDown = false;
    public GameObject missile;
    public GameObject player;
    public int missileLvl;
    private float dist = 99999;
    private GameObject target;

    IEnumerator fire()
    {
        coolDown = true;
        for (int i = 0; i < missileLvl; i++)
        {
            GameObject miss = Instantiate(missile, player.transform.position, Quaternion.identity);
            miss.GetComponent<Missile>().damage = damage;
            miss.GetComponent<Missile>().speed = speed;
            miss.GetComponent<Missile>().rotateSpeed = rotateSpeed;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(fireRate);
        coolDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown == false)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                StartCoroutine(fire());
            }  
        }
    }

    void findTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in enemies)
        {
            float gDist = Vector2.Distance(player.transform.position, g.transform.position);
            if (gDist < dist)
            {
                dist = gDist;
                target = g;
            }
        }
    }
}

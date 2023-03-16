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
    private float dist = 99999;
    private GameObject target;

    IEnumerator fire()
    {
        findTarget();
        coolDown = true;
        GameObject miss = Instantiate(missile, player.transform.position, Quaternion.identity);
        miss.GetComponent<Missile>().target = target;
        miss.GetComponent<Missile>().damage = damage;
        miss.GetComponent<Missile>().speed = speed;
        miss.GetComponent<Missile>().rotateSpeed = rotateSpeed;
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
            float gDist = Vector3.Distance(gameObject.transform.position, g.transform.position);
            if (gDist < dist)
            {
                target = g;
            }
        }
    }
}

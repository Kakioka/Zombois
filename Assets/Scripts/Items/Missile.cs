using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    public GameObject target;
    private Rigidbody2D rb;
    public float rotateSpeed;
    public int damage;
    public float life;
    public GameObject boom;
    private float dist = 99999;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(expire());
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator expire()
    {
        yield return new WaitForSeconds(life);
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        findTarget();
        if (target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;
        }
        else
        {
            rb.velocity = transform.up * speed;
            dist = 20;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //collision.GetComponent<Enemy>().health -= damage;
            GameObject boomObj = Instantiate(boom, collision.transform.position, Quaternion.identity);
            boomObj.GetComponent<BoomMissile>().damage = damage;
            Destroy(gameObject);
        }
    }

    void findTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in enemies)
        {
            float gDist = Vector2.Distance(transform.position, g.transform.position);
            if (gDist < dist)
            {
                dist = gDist;
                target = g;
            }
        }
    }
}

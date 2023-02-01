using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spitter : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed = 0.75f;

    public int damage = 1;

    public int health = 10;

    public Rigidbody2D rb;

    public bool inRange;
    public Transform firePoint;
    public GameObject bulletPre;
    public float bulletForce = 20f;
    public float fireRate = 1f;
    public bool fireDelay = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Enemy>().health = health;
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(fireRate);
        fireDelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != player.transform.position && inRange == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else if (inRange == true && fireDelay == false) 
        {
            Shoot();
        }

    }

    void FixedUpdate()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 lookDir =playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().health = collision.gameObject.GetComponent<PlayerMovement>().health - damage;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    void Shoot()
    {
        fireDelay = true;
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        bullet.GetComponent<EnemyBullet>().damage = damage;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine("Shooting");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPre;
    public float bulletForce = 20f;
    public float fireRate = 1f;
    public bool fireDelay = false;
    public Rigidbody2D rb;
    public Spitter spit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(fireRate);
        fireDelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 playerPos = spit.player.transform.position;
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void Shoot()
    {
        fireDelay = true;
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        bullet.GetComponent<EnemyBullet>().damage = spit.damage;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine("Shooting");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPre;
    public int ammo = 5;
    public int maxAmmo = 5;
    public bool isReload = false;
    public float bulletForce = 25f;
    public float reloadSpeed = 2f;
    public float fireRate = 1f;
    public bool fireDelay = false;
    public int damage = 10;
    public int piecre = 2;
    public float knockBack = 7;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    public GameObject player;
    public bool shooting = false;
    public int projectiles;
    public float bulletSize;

    // Update is called once per frame
    private void Start()
    {
        Debug.Log(ammo);
    }

    IEnumerator Reloading()
    {
        Debug.Log("reloading");
        yield return new WaitForSeconds(reloadSpeed);
        Debug.Log("reloading Done");
        ammo = maxAmmo;
        Debug.Log(ammo);
        isReload = false;
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(fireRate);
        fireDelay = false;
    }

    void Update()
    {
        transform.position = player.transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            shooting = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            shooting = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isReload == false && ammo != maxAmmo)
            {
                Reload();
            }
        }

        if (shooting)
        {
            if (ammo != 0 && isReload == false && fireDelay == false)
            {
                Shoot();
            }
            else if (ammo == 0 && isReload == false)
            {
                Reload();
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }


    void Shoot()
    {
        fireDelay = true;
        Spawn(projectiles);
        ammo--;
        Debug.Log(ammo);
        StartCoroutine("Shooting");
    }

    void Reload()
    {
        isReload = true;
        StartCoroutine("Reloading");
    }

    void Spawn(int projectiles)
    {
        switch (projectiles)
        {
            case 1:
                GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                helperSpawn(bullet);
                break;

            case 2:
                firePoint.Rotate(0f, 0f, 5f);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -10f);
                GameObject bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                firePoint.Rotate(0f, 0f, 5f);
                break;

            case 3:
                firePoint.Rotate(0f, 0f, 5f);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -10f);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 5f);
                GameObject bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                break;

            case 4:
                firePoint.Rotate(0f, 0f, -2f);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -4f);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 8f);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 4f);
                GameObject bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -6f);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                helperSpawn(bullet4);
                break;
        }

    }

    void helperSpawn(GameObject obj)
    {
        obj.GetComponent<Bullet>().damage = damage;
        obj.GetComponent<Bullet>().pierce = piecre;
        obj.GetComponent<Bullet>().knockBack = knockBack;
        obj.GetComponent<Bullet>().scale = bulletSize;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(obj.transform.up * bulletForce, ForceMode2D.Impulse);
    }
}

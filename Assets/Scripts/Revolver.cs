using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPre;
    public int ammo = 6;
    public int maxAmmo = 6;
    public bool isReload = false;
    public float bulletForce = 20f;
    public float reloadSpeed = 1f;
    public float fireRate = 0.5f;
    public bool fireDelay = false;
    public int damage = 5;
    public int piecre = 0;
    public float knockBack = 5;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    public GameObject player;
    public bool shooting = false;
    public int projectiles;
    //public Shoot p;

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
                bullet.GetComponent<Bullet>().damage = damage;
                bullet.GetComponent<Bullet>().pierce = piecre;
                bullet.GetComponent<Bullet>().knockBack = knockBack;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                break;

            case 2:
                Transform spawn1 = firePoint;
                Transform spawn2 = firePoint;
                spawn1.Rotate(40f, 0f, 0f, Space.Self);
                spawn2.Rotate(-40f, 0f, 0f, Space.Self);
                bullet = Instantiate(bulletPre, firePoint.position, spawn1.rotation);
                bullet = Instantiate(bulletPre, firePoint.position, spawn2.rotation);
                bullet.GetComponent<Bullet>().damage = damage;
                bullet.GetComponent<Bullet>().pierce = piecre;
                bullet.GetComponent<Bullet>().knockBack = knockBack;
                rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                break;
        }

    }
}

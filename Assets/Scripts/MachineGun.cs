using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPre;
    public int ammo = 20;
    public int maxAmmo = 20;
    public bool isReload = false;
    public float bulletForce = 8f;
    public float reloadSpeed = 1.5f;
    public float fireRate = 0.1f;
    public bool fireDelay = false;
    public int damage = 1;
    public int piecre = 0;
    public float knockBack = 2;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    public GameObject player;
    public bool shooting = false;

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
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().pierce = piecre;
        bullet.GetComponent<Bullet>().knockBack = knockBack;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        ammo--;
        Debug.Log(ammo);
        StartCoroutine("Shooting");
    }

    void Reload()
    {
        isReload = true;
        StartCoroutine("Reloading");
    }
}

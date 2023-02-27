using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPre;
    public int ammo;
    public int maxAmmo;
    public bool isReload = false;
    public float bulletForce;
    public float reloadSpeed;
    public float fireRate;
    public bool fireDelay = false;
    public int damage;
    public int piecre;
    public float knockBack;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    public GameObject player;
    public bool shooting = false;
    public int projectiles;
    public float bulletSize;
    public Vector3 offset;
    public bool lookingRight = true;

    // Update is called once per frame
    private void Start()
    {

    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadSpeed);
        ammo = maxAmmo;
        isReload = false;
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(fireRate);
        fireDelay = false;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
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

        if (transform.rotation.eulerAngles.z > 180 && !lookingRight)
        {
            Flip();
        }
        else if (transform.rotation.eulerAngles.z < 180 && lookingRight)
        {
            Flip();
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

            case 5:
                GameObject bullet5 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -3f);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -4f);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 10f);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 4f);
                bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -7f);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                helperSpawn(bullet4);
                helperSpawn(bullet5);
                break;

            case 6:
                firePoint.Rotate(0f, 0f, -2f);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -3f);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -3f);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 10f);
                bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 3f);
                bullet5 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 3f);
                GameObject bullet6 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -8f);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                helperSpawn(bullet4);
                helperSpawn(bullet5);
                helperSpawn(bullet6);
                break;

            case 7:
                bullet5 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -3f);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -3f);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -3f);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 12f);
                bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 3f);
                bullet6 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, 3f);
                GameObject bullet7 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -9f);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                helperSpawn(bullet4);
                helperSpawn(bullet5);
                helperSpawn(bullet6);
                helperSpawn(bullet7);
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

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

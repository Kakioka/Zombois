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

    public GameObject bullet6;
    public GameObject bullet5;
    public GameObject bullet4;
    public GameObject bullet3;
    public GameObject bullet2;
    public GameObject bullet1;


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
        if (ammo == 5)
        {
            bullet6.SetActive(false);
        }
        if (ammo == 4)
        {
            bullet5.SetActive(false);
        }
        if (ammo == 3)
        {
            bullet4.SetActive(false);
        }
        if (ammo == 2)
        {
            bullet3.SetActive(false);
        }
        if (ammo == 1)
        {
            bullet2.SetActive(false);
        }
        if (ammo == 0)
        {
            bullet1.SetActive(false);
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            if (ammo != 0 && isReload == false && fireDelay == false)
            {
                Shoot();
            }
            else if(ammo == 0 && isReload == false) {
                Reload();
                bullet6.SetActive(true);
                bullet5.SetActive(true);
                bullet4.SetActive(true);
                bullet3.SetActive(true);
                bullet2.SetActive(true);
                bullet1.SetActive(true);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (isReload == false && ammo != maxAmmo) 
            {
                Reload();
                bullet6.SetActive(true);
                bullet5.SetActive(true);
                bullet4.SetActive(true);
                bullet3.SetActive(true);
                bullet2.SetActive(true);
                bullet1.SetActive(true);
            }
        }
    }

    void Shoot() 
    {
        fireDelay = true;
        GameObject bullet =  Instantiate(bulletPre, firePoint.position, firePoint.rotation);
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

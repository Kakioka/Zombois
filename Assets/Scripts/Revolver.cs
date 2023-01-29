using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        if (Input.GetButtonDown("Fire1")) 
        {
            if (ammo != 0 && isReload == false && fireDelay == false)
            {
                Shoot();
            }
            else if(ammo == 0 && isReload == false) {
                Reload();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (isReload == false && ammo != maxAmmo) 
            {
                Reload();
            }
        }
    }

    void Shoot() 
    {
        fireDelay = true;
        GameObject bullet =  Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().damage = damage;
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

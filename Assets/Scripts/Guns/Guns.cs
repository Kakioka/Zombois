using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Guns : MonoBehaviour
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
    public TextMeshProUGUI text;

    // Update is called once per frame
    private void Start()
    {

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
        text.text = ammo.ToString();
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
                fireDelay = true;
                Spawn(projectiles);
                ammo--;
                Debug.Log(ammo);
                StartCoroutine("Shooting");
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

    void Reload()
    {
        isReload = true;
        StartCoroutine("Reloading");
    }

    void Spawn(int projectiles)
    {
        float degree = 360 / projectiles;
        for (int i = 0; i < projectiles; i++)
        {
            float rotation = i * degree;
            firePoint.rotation = Quaternion.Euler(0, 0, rotation);
            GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
            helperSpawn(bullet);
        }
    }

    void helperSpawn(GameObject bullet)
    {
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().knockBack = knockBack;
        bullet.transform.localScale *= bulletSize;
    }
}

using System.Collections;
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
    Vector2 mousePos;
    public GameObject player;
    public bool shooting = false;
    public int projectiles;
    public float bulletSize;
    public float bulletLife;
    public Vector3 offset;
    public bool lookingRight = true;


    public bool bleedOn = false;
    public int bleedLvl = 0;
    public bool splinterOn = false;
    public int splintLvl = 0;

    [SerializeField]
    private float spread;

    // Update is called once per frame
    private void Start()
    {
        ammo = maxAmmo;
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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
                gameObject.GetComponent<AudioSource>().pitch = Random.Range(.6f, 1.4f);
                gameObject.GetComponent<AudioSource>().Play();
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
                float ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f,0f, ran);
                GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                helperSpawn(bullet);
                break;

            case 2:
                firePoint.Rotate(0f, 0f, 5f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -10f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                GameObject bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                firePoint.Rotate(0f, 0f, 5f);
                break;

            case 3:
                firePoint.Rotate(0f, 0f, 5f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -10f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 5f);
                GameObject bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                break;

            case 4:
                firePoint.Rotate(0f, 0f, -2f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -4f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 8f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 4f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                GameObject bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -6f);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                helperSpawn(bullet4);
                break;

            case 5:
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                GameObject bullet5 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -4f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 10f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 4f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -7f);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                helperSpawn(bullet4);
                helperSpawn(bullet5);
                break;

            case 6:
                firePoint.Rotate(0f, 0f, -2f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 10f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet5 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                GameObject bullet6 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -8f);
                helperSpawn(bullet);
                helperSpawn(bullet2);
                helperSpawn(bullet3);
                helperSpawn(bullet4);
                helperSpawn(bullet5);
                helperSpawn(bullet6);
                break;

            case 7:
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet5 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet2 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, -3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet3 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 12f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet4 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                bullet6 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
                firePoint.Rotate(0f, 0f, 3f);
                ran = Random.Range(-spread, spread);
                firePoint.Rotate(0f, 0f, ran);
                GameObject bullet7 = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
                firePoint.Rotate(0f, 0f, -ran);
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
        obj.GetComponent<Bullet>().force = bulletForce;
        obj.GetComponent<Bullet>().splintLvl = splintLvl;
        obj.GetComponent<Bullet>().bleedLvl = bleedLvl;
        obj.GetComponent<Bullet>().life = bulletLife;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(obj.transform.up * bulletForce, ForceMode2D.Impulse);

        if (bleedOn)
        {
            obj.GetComponent<Bullet>().bleedOn = true;
        }


        if (splinterOn)
        {
            obj.GetComponent<Bullet>().splinterOn = true;
        }
    }

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


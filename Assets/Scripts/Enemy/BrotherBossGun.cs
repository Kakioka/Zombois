using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherBossGun : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPre;
    public bool isReload = false;
    public float bulletForce;
    public float fireRate;
    public bool fireDelay = false;
    public int damage;
    public int piecre;
    public float knockBack;
    public Rigidbody2D rb;
    public GameObject player;
    public bool shooting = false;
    public int projectiles;
    public float bulletSize;
    public float bulletLife;
    public Vector3 offset;
    public bool lookingRight = true;
    public GameObject sister;
    private Vector2 targetPos;
    public bool bleedOn = false;
    public int bleedLvl = 0;
    public bool splinterOn = false;
    public int splintLvl = 0;
    public bool burnOn = false;
    public int burnLvl = 0;
    public bool freezeOn = false;
    public int freezeLvl = 0;
    private float distP;
    private float distS;
    public GameObject target;
    public bool tridentOn = false;
    public int tridentDamage;
    [SerializeField]
    private GameObject trident;
    private bool tridentCoolDown;
    public float tridentTimer;

    public bool laserOn = false;
    public int laserDamage;
    [SerializeField]
    private GameObject laser;
    private bool laserCoolDown = false;
    public float laserTimer;

    [SerializeField]
    private float spread;

    public float boomScale;

    private List<GameObject> firePointList = new List<GameObject>();

    private void Start()
    {
        int j = 1;
        if (projectiles % 2 == 0)
        {
            firePointList.Add(Instantiate(firePoint, transform));
            firePointList[0].transform.Rotate(0f, 0f, (j * -5f));
            firePointList.Add(Instantiate(firePoint, transform));
            firePointList[1].transform.Rotate(0f, 0f, (j * 5f));
            for (int i = 2; i < projectiles; i++)
            {
                if (i % 2 == 0)
                {
                    j++;
                }
                firePointList.Add(Instantiate(firePoint, transform));
                if (i % 2 == 0)
                {
                    firePointList[i].transform.Rotate(0f, 0f, (j * -6.5f));
                }
                else
                {
                    firePointList[i].transform.Rotate(0f, 0f, (j * 6.5f));
                }
            }
        }
        else
        {
            firePointList.Add(firePoint);
            for (int i = 1; i < projectiles; i++)
            {
                if ((i - 1) % 2 == 0 && i != 1)
                {
                    j++;
                }

                firePointList.Add(Instantiate(firePoint, transform));
                if (i % 2 == 0)
                {
                    firePointList[i].transform.Rotate(0f, 0f, (j * -7f));
                }
                else
                {
                    firePointList[i].transform.Rotate(0f, 0f, (j * 7f));
                }
            }
        }
    }

    IEnumerator laserShoot()
    {
        laserCoolDown = true;
        GameObject temp = Instantiate(laser, firePoint.transform.position, firePoint.transform.rotation);
        temp.GetComponent<Laser>().damage = laserDamage;
        yield return new WaitForSeconds(laserTimer);
        laserCoolDown = false;
    }

    IEnumerator tridentShoot()
    {
        tridentCoolDown = true;
        GameObject temp = Instantiate(trident, firePoint.transform.position, firePoint.transform.rotation);
        temp.GetComponent<Bullet>().damage = tridentDamage;
        yield return new WaitForSeconds(tridentTimer);
        tridentCoolDown = false;
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(fireRate);
        fireDelay = false;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
       if (transform.rotation.eulerAngles.z > 180 && !lookingRight)
        {
            Flip();
        }
        else if (transform.rotation.eulerAngles.z < 180 && lookingRight)
        {
            Flip();
        }

        if (tridentOn && !tridentCoolDown)
        {
            StartCoroutine(tridentShoot());
        }

        if (laserOn && !laserCoolDown)
        {
            StartCoroutine(laserShoot());
        }
    }

    void FixedUpdate()
    {
        /*distP = Vector2.Distance(player.transform.position, gameObject.transform.position);
        distS = Vector2.Distance(sister.transform.position, gameObject.transform.position);
        if (distP < distS)
        {
            targetPos = player.transform.position;
        }
        else if (distP >= distS)
        {
            targetPos = player.transform.position;
        }*/
        targetPos = target.transform.position;
        Vector2 lookDir = targetPos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void Shoot()
    {
        fireDelay = true;
        Spawn();
        StartCoroutine("Shooting");
    }

    void Spawn()
    {
        foreach (GameObject g in firePointList)
        {
            GameObject temp = Instantiate(bulletPre, g.transform.position, g.transform.rotation);
            helperSpawn(temp);
        }
    }

    public void helperSpawn(GameObject obj)
    {
        float ran = Random.Range(-spread, spread);
        obj.transform.Rotate(0f, 0f, ran);
        obj.GetComponent<Bullet>().damage = damage;
        obj.GetComponent<Bullet>().pierce = piecre;
        obj.GetComponent<Bullet>().knockBack = knockBack;
        obj.GetComponent<Bullet>().scale = bulletSize;
        obj.GetComponent<Bullet>().force = bulletForce;
        obj.GetComponent<Bullet>().splintLvl = splintLvl;
        obj.GetComponent<Bullet>().bleedLvl = bleedLvl;
        obj.GetComponent<Bullet>().life = bulletLife;
        obj.GetComponent<Bullet>().explodeScale = boomScale;
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(obj.transform.up * bulletForce, ForceMode2D.Impulse);
        obj.GetComponent<Bullet>().bleedOn = bleedOn;
        obj.GetComponent<Bullet>().splinterOn = splinterOn;
        obj.GetComponent<Bullet>().burnLvl = burnLvl;
        obj.GetComponent<Bullet>().burnOn = burnOn;
        obj.GetComponent<Bullet>().freezeLvl = freezeLvl;
        obj.GetComponent<Bullet>().freezeOn = freezeOn;
    }

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}


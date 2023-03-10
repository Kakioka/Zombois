using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Transform firePoint;
    public GameObject bulletPre;
    public int damage;
    public float bulletForce;
    public int piecre;
    public float knockBack;

    void Start()
    {
        firePoint = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn(int projectiles)
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
                spawn1.Rotate(10f, 0f, 0f, Space.Self);
                spawn2.Rotate(-10f, 0f, 0f, Space.Self);
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

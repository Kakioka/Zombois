using System.Collections;
using UnityEngine;

public class Spitter : MonoBehaviour
{
    public GameObject player;
    public GameObject sister;
    public int damage;
    public Rigidbody2D rb;
    public Transform firePoint;
    public GameObject bulletPre;
    public float bulletForce;
    public float fireRate;
    public bool fireDelay = false;
    public float maxDist;
    private Vector2 targetPos;
    private float distP;
    private float distS;
    public bool lookingRight = true;
    private Animator ani;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        player = this.gameObject.GetComponent<Enemy>().player;
        sister = this.gameObject.GetComponent<Enemy>().sister;
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(fireRate);
        fireDelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        distP = Vector3.Distance(player.transform.position, gameObject.transform.position);
        distS = Vector3.Distance(sister.transform.position, gameObject.transform.position);
        if (transform.position != player.transform.position || transform.position != sister.transform.position)
        {
            if (distP < distS && distP > maxDist)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, player.transform.position, this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
                if ((temp.x - transform.position.x > 0) && !lookingRight)
                {
                    Flip();
                }
                else if ((temp.x - transform.position.x < 0) && lookingRight)
                {
                    Flip();
                }
                Vector3 moveDir = (player.transform.position - transform.position).normalized;
                transform.position += moveDir * this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime;
                ani.SetBool("move", true);
            }
            else if (distP >= distS && distS > maxDist)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, sister.transform.position, this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
                if ((temp.x - transform.position.x > 0) && !lookingRight)
                {
                    Flip();
                }
                else if ((temp.x - transform.position.x < 0) && lookingRight)
                {
                    Flip();
                }
                Vector3 moveDir = (sister.transform.position - transform.position).normalized;
                transform.position += moveDir * this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime;
                ani.SetBool("move", true);
            }
            else if (distP <= maxDist || distS <= maxDist)
            {
                if (fireDelay == false)
                {
                    ani.SetBool("move", false);
                    Shoot();
                }
            }
        }

    }

    void FixedUpdate()
    {
        if (distP < distS)
        {
            targetPos = player.transform.position;
        }
        else if (distP >= distS)
        {
            targetPos = sister.transform.position;
        }
        Vector2 lookDir = targetPos - rb.position;
        if (lookDir.x > 0 && !lookingRight)
        {
            Flip();
        }
        else if (lookDir.x < 0 && lookingRight)
        {
            Flip();
        }
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().health = collision.gameObject.GetComponent<PlayerMovement>().health - damage;
        }
        if (collision.gameObject.tag == "Sister")
        {
            collision.gameObject.GetComponent<Sister>().health = collision.gameObject.GetComponent<Sister>().health - damage;
        }
    }

    void Shoot()
    {
        fireDelay = true;
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        bullet.GetComponent<EnemyBullet>().damage = damage;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine("Shooting");
    }

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

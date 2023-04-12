using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherBoss : MonoBehaviour
{
    public GameObject player;
    public GameObject sister;
    public int damage;
    public Rigidbody2D rb;
    private Rigidbody2D rbLocal;
    public float maxDist;
    private Vector2 targetPos;
    private float distP;
    private float distS;
    public bool lookingRight = true;
    private Animator ani;
    public GameObject gun;

    //circle shit
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rbLocal = GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();
        player = this.gameObject.GetComponent<Enemy>().player;
        sister = this.gameObject.GetComponent<Enemy>().player;
    }

    private IEnumerator knockBack()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Enemy>().knock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().knock == true)
        {
            StartCoroutine(knockBack());
        }
        distP = Vector2.Distance(player.transform.position, gameObject.transform.position);
        distS = Vector2.Distance(sister.transform.position, gameObject.transform.position);
        if (transform.position != player.transform.position || transform.position != sister.transform.position)
        {
            if (distP < distS && distP > maxDist)
            {
                Vector2 temp = Vector2.MoveTowards(transform.position, player.transform.position, this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
                if ((temp.x - transform.position.x > 0) && !lookingRight)
                {
                    Flip();
                }
                else if ((temp.x - transform.position.x < 0) && lookingRight)
                {
                    Flip();
                }
                if (gameObject.GetComponent<Enemy>().knock == false)
                {
                    Vector2 direction = (Vector2)player.transform.position - rbLocal.position;
                    direction.Normalize();
                    rbLocal.velocity = direction * gameObject.GetComponent<Enemy>().moveSpeed;
                    ani.SetBool("move", true);
                }

            }
            else if (distP >= distS && distS > maxDist)
            {
                Vector2 temp = Vector2.MoveTowards(transform.position, sister.transform.position, this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
                if ((temp.x - transform.position.x > 0) && !lookingRight)
                {
                    Flip();
                }
                else if ((temp.x - transform.position.x < 0) && lookingRight)
                {
                    Flip();
                }
                if (gameObject.GetComponent<Enemy>().knock == false)
                {
                    Vector2 direction = (Vector2)sister.transform.position - rbLocal.position;
                    direction.Normalize();
                    rbLocal.velocity = direction * gameObject.GetComponent<Enemy>().moveSpeed;
                    ani.SetBool("move", true);
                }

            }
            else if (distP <= maxDist || distS <= maxDist)
            {
                Circle();
                if (gun.GetComponent<BrotherBossGun>().fireDelay == false)
                {
                    gun.GetComponent<BrotherBossGun>().Shoot();
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

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Circle()
    {
        /*
         * 
         * OG code that works but w/ somewhat jerky movement
         * 
        //set player as center of circle
        var center = player.transform.position;

        //calculate angle betwen current position and player
        var offset = transform.position - center;
        float angle = Mathf.Atan2(offset.y, offset.x);

        //increment the angle to move object along circle
        angle += RotateSpeed * Time.deltaTime;

        //calculate new offset basedon incremented angle
        offset.x = Mathf.Cos(angle) * maxDist;
        offset.y = Mathf.Sin(angle) * maxDist;
        
        //set position of the object to be the new position on circle
        transform.position = center + offset;
        */

        //rotates gameObject around player
        //note* keep RotateSpeed low, it's pretty fast when it's high

        //set player as center of circle
        var center = player.transform.position;

        //calculate angle betwen current position and player
        var offset = transform.position - center;
        float angle = Mathf.Atan2(offset.y, offset.x);

        //increment the angle to move object along circle
        angle += Time.deltaTime * RotateSpeed;

        //calculate new offset basedon incremented angle
        offset.x = Mathf.Cos(angle) * maxDist;
        offset.y = Mathf.Sin(angle) * maxDist;

        //normalize offset
        offset = Vector3.Lerp(offset.normalized * maxDist, offset, Time.deltaTime);

        //set position of the object to be the new position on circle
        transform.position = center + offset;

    }
}

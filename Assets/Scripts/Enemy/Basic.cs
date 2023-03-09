using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{

    public GameObject player;

    public GameObject sister;

    public int damage = 1;

    public float health = 10;

    public bool lookingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<Enemy>().player;
        sister = this.gameObject.GetComponent<Enemy>().sister;
        gameObject.GetComponent<Enemy>().health = health;
    }

    // Update is called once per frame
    void Update()
    {
        float distP = Vector3.Distance(player.transform.position, gameObject.transform.position);
        float distS = Vector3.Distance(sister.transform.position, gameObject.transform.position);
        if (transform.position != player.transform.position || transform.position != sister.transform.position)
        {
            if (distP < distS)
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
            }
            else if (distP >= distS)
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
            }
        }
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
}

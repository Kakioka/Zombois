using UnityEngine;
using System.Collections;

public class Basic : MonoBehaviour
{
    public GameObject player;
    public GameObject sister;
    public int damage = 1;
    public bool lookingRight = true;
    private Rigidbody2D rb;

    private IEnumerator knockBack()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Enemy>().knock = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Enemy>().player;
        sister = gameObject.GetComponent<Enemy>().sister;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Enemy>().knock)
        {
            StartCoroutine(knockBack());
            return;
        }
        float distP = Vector3.Distance(player.transform.position, gameObject.transform.position);
        float distS = Vector3.Distance(sister.transform.position, gameObject.transform.position);
        if (transform.position != player.transform.position || transform.position != sister.transform.position)
        {
            if (distP < distS)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, player.transform.position, gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
                if ((temp.x - transform.position.x > 0) && !lookingRight)
                {
                    Flip();
                }
                else if ((temp.x - transform.position.x < 0) && lookingRight)
                {
                    Flip();
                }

                if (!GetComponent<Enemy>().knock)
                {
                    Vector2 direction = (Vector2)player.transform.position - rb.position;
                    direction.Normalize();
                    rb.velocity = direction * gameObject.GetComponent<Enemy>().moveSpeed;

                }
                
            }
            else if (distP >= distS)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, sister.transform.position, gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
                if ((temp.x - transform.position.x > 0) && !lookingRight)
                {
                    Flip();
                }
                else if ((temp.x - transform.position.x < 0) && lookingRight)
                {
                    Flip();
                }

                if (!GetComponent<Enemy>().knock)
                {
                    Vector2 direction = (Vector2)sister.transform.position - rb.position;
                    direction.Normalize();
                    rb.velocity = direction * gameObject.GetComponent<Enemy>().moveSpeed;

                }
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

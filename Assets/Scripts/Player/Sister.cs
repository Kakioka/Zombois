using System.Collections;
using UnityEngine;

public class Sister : MonoBehaviour
{
    public GameObject player;
    public float maxDist;
    public int health;
    public int armor = 0;
    public int maxHealth;
    public bool isInv = false;
    public float invTimer = 1f;
    public int prevHealth;
    public float moveSpeed;
    public GameObject ring;
    public bool lookingRight = true;
    private Animator ani;
    private Rigidbody2D rb;

    public float pickUpRadius;
    public CircleCollider2D pickUp;
    public float pingPongSpeed;
    public float flashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        pickUp.radius = pickUpRadius;
        rb = GetComponent<Rigidbody2D>();
        prevHealth = health;
        ring.SetActive(false);
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInv)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.clear, flashSpeed * Mathf.PingPong(Time.time, pingPongSpeed));
        }

        Vector3 temp = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        if ((temp.x - transform.position.x > 0) && !lookingRight)
        {
            Flip();
        }
        else if ((temp.x - transform.position.x < 0) && lookingRight)
        {
            Flip();
        }

        if (health <= 0)
        {
            //Destroy(gameObject);
        }

        if (health != prevHealth)
        {
            StartCoroutine(invincible());
        }

        float distP = Vector3.Distance(player.transform.position, gameObject.transform.position);

        if (transform.position != player.transform.position && distP > maxDist)
        {
            Vector2 direction = (Vector2)player.transform.position - rb.position;
            direction.Normalize();
            rb.velocity = direction * moveSpeed;
            ani.SetBool("move", true);
        }
        else
        {
            ani.SetBool("move", false);
        }
        if (player.GetComponent<PlayerMovement>().isInv && !isInv)
        {
            StartCoroutine(invincible());
        }
    }

    public IEnumerator invincible()
    {
        if (armor > 0 && health != prevHealth)
        {
            armor--;
            health++;
        }
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        isInv = true;
        prevHealth = health;
        ring.SetActive(true);
        yield return new WaitForSeconds(invTimer);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        ring.SetActive(false);
        isInv = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
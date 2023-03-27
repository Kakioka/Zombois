using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int health = 3;
    public int prevHealth;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public bool isDead = false;
    public Animator ani;
    public float invTimer = 1f;
    public GameObject ring;
    public bool isInv = false;
    public int bank = 0;
    public float pickUpRadius;
    public CircleCollider2D pickUp;
    public bool lookingRight = true;

    public float pingPongSpeed;
    public float flashSpeed;

    public float speedReduction;
    public bool speedReduced;

    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        prevHealth = health;
        ring.SetActive(false);
        pickUp.radius = pickUpRadius;
        ani = gameObject.GetComponent<Animator>();
    }

    public IEnumerator invincible()
    {
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

    // Update is called once per frame
    void Update()
    {
        if (isInv)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.clear, flashSpeed * Mathf.PingPong(Time.time, pingPongSpeed));
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x == 0 && movement.y == 0)
        {
            ani.SetBool("move", false);
        }
        else
        {
            ani.SetBool("move", true);
        }
        if (health <= 0)
        {
            isDead = true;
        }

        if (health != prevHealth && !isInv)
        {
            StartCoroutine(invincible());
        }

        if (movement.x > 0 && !lookingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && lookingRight)
        {
            Flip();
        }


        if (Input.GetButton("Fire1") && !speedReduced)
        {
            speedReduced = true;
            moveSpeed *= speedReduction;
        }

        if ((Input.GetButtonUp("Fire1") && speedReduced) || (gun.GetComponent<Gun>().isReload && speedReduced))
        {
            speedReduced = false;
            moveSpeed /= speedReduction;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInv == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
            }
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

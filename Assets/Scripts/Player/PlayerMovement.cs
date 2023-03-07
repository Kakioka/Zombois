using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // Start is called before the first frame update
    void Start()
    {
        prevHealth = health;
        ring.SetActive(false);
        pickUp.radius = pickUpRadius;
    }

    private IEnumerator invincible()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        isInv = true;
        prevHealth = health;
        ring.SetActive(true);
        yield return new WaitForSeconds(invTimer);
        ring.SetActive(false);
        isInv = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (health <= 0)
        {
            isDead = true;
        }

        if (health != prevHealth)
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

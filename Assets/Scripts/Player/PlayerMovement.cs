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
    Vector2 mousePos;
    public Camera cam;
    public bool isDead = false;
    public Animator ani;
    public float invTimer = 1f;
    public GameObject ring;
    public bool isInv = false;
    public int bank = 0;
    public float pickUpRadius;
    public CircleCollider2D pickUp;
    public TextMeshProUGUI healthText;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;
    private SpriteRenderer health3Renderer;
    private SpriteRenderer health2Renderer;
    private SpriteRenderer health1Renderer;

    // Start is called before the first frame update
    void Start()
    {
        prevHealth = health;
        ring.SetActive(false);
        pickUp.radius = pickUpRadius;

        ani = GetComponent<Animator>();
        ani.SetBool("Dead", true);

        health3Renderer = health3.GetComponent<SpriteRenderer>();
        health2Renderer = health2.GetComponent<SpriteRenderer>();
        health1Renderer = health1.GetComponent<SpriteRenderer>();
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
        healthText.text = health.ToString();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (health <= 0)
        {
            isDead = true;
        }

        if (health != prevHealth)
        {
            StartCoroutine(invincible());
        }

        if (health == 2)
        {
            ani.SetBool("IsHitOnce", true);
            health3Renderer.color = Color.black;
        }
        if (health == 1)
        {
            ani.SetBool("IsHitOnce", false);
            ani.SetBool("IsHitTwice", true);
            health2Renderer.color = Color.black;
        }
        else
        {
            ani.SetBool("IsHitTwice", false);
        }

        if (health <= 0)
        {
            Debug.Log("dead");
            isDead = true;
            health1Renderer.color = Color.black;
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
}

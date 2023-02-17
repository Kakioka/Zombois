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
        Debug.Log("inv");
        ring.SetActive(true);
        yield return new WaitForSeconds(invTimer);
        ring.SetActive(false);
        Debug.Log("not inv");
        isInv = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();

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

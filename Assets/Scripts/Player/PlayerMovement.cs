using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        prevHealth = health;
        ring.SetActive(false);
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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (health <= 0)
        {
            Debug.Log("dead");
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

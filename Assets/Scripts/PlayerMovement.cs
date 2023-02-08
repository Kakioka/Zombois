using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int health = 3;
    
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    public Camera cam;

    public bool isDead = false;

    public Animator ani;

    public GameObject player;

    public GameObject health3;

    public GameObject health2;
    
    public GameObject health1;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("Dead", true);   
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (health == 2)
        {
            ani.SetBool("IsHitOnce", true);
            health3.SetActive(false);

        }
        if (health == 1)
        {
            ani.SetBool("IsHitOnce", false);
            ani.SetBool("IsHitTwice", true);
            health2.SetActive(false);
        }
        else
        {
            ani.SetBool("IsHitTwice", false);
        }

        if (health <= 0)
        {
            Debug.Log("dead");
            isDead = true;
            player.SetActive(false);
            health1.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}

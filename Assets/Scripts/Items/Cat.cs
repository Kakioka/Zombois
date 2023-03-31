using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    private float maxDist;
    private float dist = 9999;
    private GameObject target;
    private bool lookingRight = true;
    [SerializeField]
    private bool attacked = false;
    private Animator ani;
    [SerializeField]
    private GameObject damageNum;
    [SerializeField]
    private float radius;
    private Rigidbody2D rb;

    public GameObject player;

    public float attackCD;

    public int damage;


    private IEnumerator attack(Collider2D collision) 
    {
        attacked = true;
        collision.GetComponent<Enemy>().health -= damage;
        Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
        temp.z = 10;
        GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
        num.transform.position += new Vector3(0.25f, 0f);
        num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
        Destroy(num, 1f);
        ani.SetBool("move", false);
        yield return new WaitForSeconds(attackCD);
        dist = 9999;
        attacked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!attacked) 
        {
            
            if (target != null)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
                if ((temp.x - transform.position.x > 0) && !lookingRight)
                {
                    Flip();
                }
                else if ((temp.x - transform.position.x < 0) && lookingRight)
                {
                    Flip();
                }

                float distP = Vector3.Distance(target.transform.position, gameObject.transform.position);

                if (transform.position != target.transform.position && distP > maxDist)
                {
                    Vector2 direction = (Vector2)target.transform.position - rb.position;
                    direction.Normalize();
                    rb.velocity = direction * moveSpeed;
                    ani.SetBool("move", true);
                }
                else
                {
                    ani.SetBool("move", false);
                }
            }
            else
            {
                dist = 9999;
                findTarget();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            if (!attacked) 
            {
                StartCoroutine(attack(collision));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!attacked)
            {
                StartCoroutine(attack(collision));
            }
        }
    }

    void findTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in enemies)
        {
            float gDist = Vector2.Distance(player.transform.position, g.transform.position);
            if (gDist < dist)
            {
                dist = gDist;
                target = g;
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

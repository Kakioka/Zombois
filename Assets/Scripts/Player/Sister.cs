using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.VirtualTexturing;
using System.Net.NetworkInformation;

public class Sister : MonoBehaviour
{
    public GameObject player;
    public float maxDist;
    public int health;
    public bool isInv = false;
    public float invTimer = 1f;
    public int prevHealth;
    public float moveSpeed;
    public GameObject ring;
    public bool lookingRight = true;
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        prevHealth = health;
        ring.SetActive(false);
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
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

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{

    public GameObject player;

    public float moveSpeed = 1f;

    public int damage = 1;

    public int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Enemy>().health = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != player.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerMovement>().health = collision.gameObject.GetComponent<PlayerMovement>().health - damage;
        }
    }
}

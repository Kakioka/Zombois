using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public PlayerMovement player;
    public Sister sister;

    private bool pRing;

    // Start is called before the first frame update
    void Start()
    {
 
            player = transform.GetComponentInParent<PlayerMovement>();

            sister = transform.GetComponentInParent<Sister>();

        if (player != null)
        {
            pRing = true;
        }
        else 
        {
            pRing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (pRing)
            {
                StartCoroutine(player.invincible());
            }
            else 
            {
                StartCoroutine(sister.invincible());
            }
            gameObject.GetComponent<CircleCollider2D>().enabled= false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1.5f);
        }
    }
}

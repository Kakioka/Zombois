using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public PlayerMovement player;
    public Sister sister;
    public int bubbleLvl;
    public float speedMod;

    private bool pRing;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponentInParent<PlayerMovement>();
        sister = transform.GetComponentInParent<Sister>();
        if (player != null)
        {
            pRing = true;
            player.moveSpeed *= (1 + (speedMod * bubbleLvl));
        }
        else 
        {
            pRing = false;
            sister.moveSpeed *= (1 + (speedMod * bubbleLvl));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (pRing)
            {
                StartCoroutine(player.invincible());
                player.moveSpeed /= (1+(speedMod * bubbleLvl));
            }
            else 
            {
                StartCoroutine(sister.invincible());
                sister.moveSpeed /= (1+(speedMod * bubbleLvl));
            }
            gameObject.GetComponent<CircleCollider2D>().enabled= false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 1.5f);
        }
    }
}

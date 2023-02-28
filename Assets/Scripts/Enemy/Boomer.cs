using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : MonoBehaviour
{
    public GameObject player;
    public GameObject sister;
    public int damage = 1;
    public float health = 10;
    public bool inRange = false;
    public float timer = 0.5f;
    public GameObject explosion;
    public float maxDist;

    private IEnumerator explode()
    {
        yield return new WaitForSeconds(timer);
        GameObject boom = Instantiate(explosion, transform.position, transform.rotation);
        gameObject.GetComponent<Enemy>().health = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<Enemy>().player;
        sister = this.gameObject.GetComponent<Enemy>().sister;
        gameObject.GetComponent<Enemy>().health = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().health <= 0)
        {
            GameObject boom = Instantiate(explosion, transform.position, transform.rotation);
        }
        float distP = Vector3.Distance(player.transform.position, gameObject.transform.position);
        float distS = Vector3.Distance(sister.transform.position, gameObject.transform.position);
        if (transform.position != player.transform.position || transform.position != sister.transform.position)
        {
            if (distP < distS)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
            }
            else if (distP >= distS)
            {
                transform.position = Vector3.MoveTowards(transform.position, sister.transform.position, this.gameObject.GetComponent<Enemy>().moveSpeed * Time.deltaTime);
            }
        }
        if (inRange == true)
        {
            StartCoroutine(explode());
        }
        if (distP <= maxDist || distS <= maxDist)
        {
            inRange = true;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().health = collision.gameObject.GetComponent<PlayerMovement>().health - damage;
        }
        if (collision.gameObject.tag == "Sister")
        {
            collision.gameObject.GetComponent<Sister>().health = collision.gameObject.GetComponent<Sister>().health - damage;
        }
    }
}

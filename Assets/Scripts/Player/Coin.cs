using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public GameObject player;
    public GameObject sister;
    public int moveSpeed;
    public bool pickedUp = false;
    public bool pickedUpS = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUpS) 
        {
            Vector3 moveDir = (sister.transform.position - transform.position).normalized;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
        if (pickedUp) 
        {
            Vector3 moveDir = (player.transform.position - transform.position).normalized;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            player.GetComponent<PlayerMovement>().bank += value;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PickUp")
        {
            pickedUp = true;
        }
        if (collision.gameObject.tag == "PickUpS")
        {
            pickedUpS = true;
        }
    }
}

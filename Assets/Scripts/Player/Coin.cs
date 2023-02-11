using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public GameObject player;
    public int moveSpeed;
    public bool pickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp) 
        {
            move();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PickUp") 
        {
            pickedUp = true;
        }

        if (collision.gameObject.tag == "Player") 
        {
            player.GetComponent<PlayerMovement>().bank += value;
            Debug.Log(player.GetComponent<PlayerMovement>().bank);
            Destroy(gameObject);
        }
    }

    void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}

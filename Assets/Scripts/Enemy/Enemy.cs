using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject coinPref;
    public GameObject player;
    public GameObject sister;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (health <= 0) 
        {
            GameObject coin = Instantiate(coinPref, transform.position, Quaternion.identity);
            coin.GetComponent<Coin>().player = player;
            Destroy(gameObject);
        }
    }
}

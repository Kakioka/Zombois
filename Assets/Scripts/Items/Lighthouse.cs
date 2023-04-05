using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour
{

    private GameObject player;
    private GameObject gun;
    public int lightLvl;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Sister>().player;       
        gun = player.GetComponent<PlayerMovement>().gun;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            gun.GetComponent<Gun>().damage = Mathf.CeilToInt(gun.GetComponent<Gun>().damage * (1 + (0.2f * lightLvl)));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gun.GetComponent<Gun>().damage = Mathf.FloorToInt(gun.GetComponent<Gun>().damage / (1 + (0.2f * lightLvl)));
        }
    }
}

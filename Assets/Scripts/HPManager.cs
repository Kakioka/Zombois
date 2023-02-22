using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public int health = 3;
    public bool isDead = false;
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetBool("Dead", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 2)
        {
            ani.SetBool("IsHitOnce", true);
            //health3.SetActive(false);

        }
        if (health == 1)
        {
            ani.SetBool("IsHitOnce", false);
            ani.SetBool("IsHitTwice", true);
            //health2.SetActive(false);
        }
        else
        {
            //ani.SetBool("IsHitTwice", false);
        }

        if (health <= 0)
        {
            Debug.Log("dead");
            isDead = true;
            //health1.SetActive(false);
        }
    }
}

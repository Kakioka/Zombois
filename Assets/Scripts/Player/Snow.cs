using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.AxisState;

public class Snow : MonoBehaviour
{

    public float speedMod;
    public float radius = 0.08f;
    public CircleCollider2D range;

    // Start is called before the first frame update
    void Start()
    {
        range.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().moveSpeed *= speedMod;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().moveSpeed /= speedMod;
        }
    }
}

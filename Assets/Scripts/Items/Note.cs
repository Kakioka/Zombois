using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Gun gun;
    public BeatsManager beatsManager;

    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private float timeUp;
    private bool inGreen = false;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void hitNice(Collider2D collision)
    {
        GameObject effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (inGreen)
            {
                hitNice(col);
                beatsManager.timer += timeUp;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bar")
        {
            inGreen = true;
            col = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Bar")
        {
            inGreen = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Gun gun;
    public BeatsManager beatsManager;

    [SerializeField]
    private float timeUp;
    private bool inGreen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (inGreen)
            {
                beatsManager.timer += timeUp;
                Debug.Log("nice");
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bar")
        {
            inGreen = true;
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

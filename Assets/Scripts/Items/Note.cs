using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Gun gun;
    public BeatsManager beatsManager;

    [SerializeField]
    private float timeUp;
    public GameObject nicePos;
    [SerializeField]
    private GameObject nice;
    private bool inGreen = false;
    private Collider2D col;

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
                GameObject temp = Instantiate(nice, nicePos.transform);
                temp.transform.Rotate(0f, 0f, Random.Range(-20, 20));
                Destroy(temp, 0.5f);
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

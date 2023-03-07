using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterShoot : MonoBehaviour
{
    public GameObject spit;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = spit.transform.position + offset;
    }

    void FixedUpdate()
    {
        gameObject.transform.position = spit.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject text;
    public Transform initial;

    void Start()
    {
        initial = text.transform;
    }

    // Update is called once per frame
    void Update()
    {
        text.transform.position =  initial.position + target.transform.position;
    }
}

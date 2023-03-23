using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPistols : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(gameObject);
        temp.GetComponent<Gun>().offset = new Vector3(-0.1f,-0.2f,0f);
        Destroy(temp.GetComponent<DualPistols>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

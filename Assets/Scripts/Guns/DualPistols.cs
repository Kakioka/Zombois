using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPistols : MonoBehaviour
{
    private GameObject temp;
    public GameObject parent;
    public bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnCopy();
    }

    private void spawnCopy()
    {
        if (!check)
        {
            temp = Instantiate(gameObject);
            temp.GetComponent<Gun>().offset = new Vector3(-0.1f, -0.1f, 0f);
            temp.GetComponent<DualPistols>().parent = gameObject;
            temp.GetComponent<DualPistols>().check = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
           
            if (parent == null)
            {
                Destroy(gameObject);
            } 
            
            GetComponent<Gun>().damage = parent.GetComponent<Gun>().damage;
        }
    }
}

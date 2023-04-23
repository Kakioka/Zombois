using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDualPistols : MonoBehaviour
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
            temp.GetComponent<BrotherBossGun>().offset = new Vector3(-0.1f, -0.1f, 0f);
            temp.GetComponent<BDualPistols>().parent = gameObject;
            temp.GetComponent<BDualPistols>().check = true;
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
            else
            {
                GetComponent<BrotherBossGun>().damage = parent.GetComponent<BrotherBossGun>().damage;
            }
        }
    }
}

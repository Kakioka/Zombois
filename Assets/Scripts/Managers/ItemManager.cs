using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();

    public Transform item1;
    public Transform item2;
    public Transform item3;
    public Transform item4;
    public Transform item5;
    public Transform item6;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Items[Random.Range(0, Items.Count)], item1);
        Instantiate(Items[Random.Range(0, Items.Count)], item2);
        Instantiate(Items[Random.Range(0, Items.Count)], item3);
        Instantiate(Items[Random.Range(0, Items.Count)], item4);
        Instantiate(Items[Random.Range(0, Items.Count)], item5);
        Instantiate(Items[Random.Range(0, Items.Count)], item6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

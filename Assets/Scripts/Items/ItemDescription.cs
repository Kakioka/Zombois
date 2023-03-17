using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    public string description;

    public Sprite item;
    public SpriteRenderer itemDescription;

    public TMP_Text itemName;

    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemDescription.sprite = item;
    }
}

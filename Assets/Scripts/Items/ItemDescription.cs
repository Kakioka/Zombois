using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    public string description;
    public TMP_Text descriptionT;

    public Sprite item;
    public SpriteRenderer itemDescription;

    public TMP_Text itemNameT;
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        descriptionT.text = description;
        itemDescription.sprite = item;
        itemNameT.text = itemName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

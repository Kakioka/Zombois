using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBrother : MonoBehaviour
{

    //This code duplicates the current player and makes it attack the player

    public GameObject brother;

    public void Spawn()
    {
        brother = Instantiate(gameObject);
    }

    void Start()
    {

    }

}

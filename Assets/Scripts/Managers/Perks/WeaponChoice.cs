using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChoice : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> choices = new List<GameObject>();

    [SerializeField]
    private List<GameObject> wepCards = new List<GameObject>();

    [SerializeField]
    //private List<GameObject> wepChoices = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject temp = Instantiate(wepCards[Random.Range(0, wepCards.Count)], choices[i].transform);
            temp.GetComponent<weaponCard>().wepCost = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skip()
    {
        Destroy(gameObject);
    }
}

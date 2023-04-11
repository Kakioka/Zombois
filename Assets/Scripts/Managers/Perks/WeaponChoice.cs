using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChoice : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> choices = new List<GameObject>();

    [SerializeField]
    private List<GameObject> wepCards = new List<GameObject>();

    private GameObject choice;

    [SerializeField]
    //private List<GameObject> wepChoices = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        choice = this.gameObject;
        for (int i = 0; i < 3; i++)
        {
            GameObject temp = Instantiate(wepCards[Random.Range(0, wepCards.Count)], choices[i].transform);
            temp.GetComponent<weaponCard>().wepCost = 0;
            temp.GetComponentInChildren<Button>().onClick.AddListener(skip);
        }
    }

    private void Awake()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skip()
    {
        Time.timeScale = 1;
        Destroy(choice);
    }
}

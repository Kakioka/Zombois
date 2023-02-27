using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pHealth;
    public TextMeshProUGUI sHealth;
    public TextMeshProUGUI ammo;

    public GameObject player;
    public GameObject sister;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pHealth.text = player.GetComponent<PlayerMovement>().health.ToString();
        sHealth.text = sister.GetComponent<Sister>().health.ToString();
        ammo.text = gun.GetComponent<Gun>().ammo.ToString() + "/" + gun.GetComponent<Gun>().maxAmmo.ToString();
    }
}

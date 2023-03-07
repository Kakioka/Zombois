using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeShopTabs : MonoBehaviour
{
    public GameObject Guns;
    public GameObject wepUp;
    public GameObject Vac;
    public GameObject playerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wepUpTab() 
    {
        wepUp.SetActive(true);
        Guns.SetActive(false);
        Vac.SetActive(false);
        playerUp.SetActive(false); 
    }

    public void gunTab() 
    {
        wepUp.SetActive(false);
        Guns.SetActive(true);
        Vac.SetActive(false);
        playerUp.SetActive(false);
    }

    public void vacTab() 
    {
        wepUp.SetActive(false);
        Guns.SetActive(false);
        Vac.SetActive(true);
        playerUp.SetActive(false);
    }

    public void playerUpTab() 
    {
        wepUp.SetActive(false);
        Guns.SetActive(false);
        Vac.SetActive(false);
        playerUp.SetActive(true);
    }
}

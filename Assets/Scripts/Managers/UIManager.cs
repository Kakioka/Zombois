using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Rendering.VirtualTexturing;

public class UIManager : MonoBehaviour
{
    public GameObject gameManager;

    public TextMeshProUGUI sHealth;
    public TextMeshProUGUI ammo;
    public TextMeshProUGUI cash;

    public GameObject player;
    public GameObject sister;
    public GameObject gun;

    //public Animator aniHealth;
    public SpriteRenderer h3;
    public SpriteRenderer h2;
    public SpriteRenderer h1;

    public Animator aniGun;

    // Start is called before the first frame update
    void Start()
    {
        h1.color = Color.red;
        h2.color = Color.red;
        h3.color = Color.red;
        aniGun.speed /= gun.GetComponent<Gun>().reloadSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        cash.text = "Cash: " + gameManager.GetComponent<gameManager>().bank.ToString();
        sHealth.text = sister.GetComponent<Sister>().health.ToString();
        ammo.text = gun.GetComponent<Gun>().ammo.ToString() + "/" + gun.GetComponent<Gun>().maxAmmo.ToString();
        
        switch (player.GetComponent<PlayerMovement>().health) 
        {
            case 0:
                h1.color = Color.black;
                h2.color = Color.black;
                h3.color = Color.black;
                break;
            case 1:
                //aniHealth.SetInteger("health", player.GetComponent<PlayerMovement>().health);
                h1.color = Color.red;
                h2.color = Color.black;
                h3.color = Color.black;
                break;
            case 2:
                //aniHealth.SetInteger("health", player.GetComponent<PlayerMovement>().health);
                h3.color = Color.black;
                h1.color = Color.red;
                h2.color = Color.red;
                break;
            case 3:
                h1.color = Color.red;
                h2.color = Color.red;
                h3.color = Color.red;
                //aniHealth.SetInteger("health", player.GetComponent<PlayerMovement>().health);
                break;
        }
        aniGun.SetBool("ReloadTrigger", gun.GetComponent<Gun>().isReload);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    [SerializeField]
    private int numBullets;
    [SerializeField]
    private GameObject firePoint;
    public GameObject player;
    private GameObject gun;
    private GameObject bullet;
    private bool fired;
    [SerializeField]
    private float rotation;
    [SerializeField]
    private float delay;
    // Start is called before the first frame update
    void Start()
    {
        gun = player.GetComponentInParent<PlayerMovement>().gun;
        bullet = gun.GetComponent<Gun>().bulletPre;
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        if (gun.GetComponent<Gun>().isReload && !fired)
        {
            StartCoroutine(circleFire());
        }
        else if (!gun.GetComponent<Gun>().isReload && fired)
        {
            fired = false;
        }
    }

    IEnumerator circleFire()
    {
        fired = true;
        for (int i = 0; i < numBullets; i++)
        {
            yield return new WaitForSeconds(delay);
            GameObject temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            gun.GetComponent<Gun>().helperSpawn(temp);
            temp.GetComponent<Bullet>().damage *= Mathf.CeilToInt(0.4f);
            firePoint.transform.Rotate(0f, 0f, -rotation);
        }
        
    }
}

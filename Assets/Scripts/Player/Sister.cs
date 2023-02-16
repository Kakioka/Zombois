using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using UnityEngine;

public class Sister : MonoBehaviour
{
    public int health;
    public bool isInv = false;
    public float invTimer = 1f;
    public int prevHealth;

    // Start is called before the first frame update
    void Start()
    {
        prevHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health != prevHealth)
        {
            StartCoroutine(invincible());
        }
    }

    private IEnumerator invincible()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        isInv = true;
        prevHealth = health;
        Debug.Log("inv");
        yield return new WaitForSeconds(invTimer);
        Debug.Log("not inv");
        isInv = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

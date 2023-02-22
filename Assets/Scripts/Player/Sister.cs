using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sister : MonoBehaviour
{
    public int health;
    public bool isInv = false;
    public float invTimer = 1f;
    public int prevHealth;
    public TextMeshProUGUI sisHealthText;

    // Start is called before the first frame update
    void Start()
    {
        prevHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        sisHealthText.text = health.ToString();
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
        yield return new WaitForSeconds(invTimer);
        isInv = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.VirtualTexturing;

public class Sister : MonoBehaviour
{
    public GameObject player;
    public float maxDist;
    public int health;
    public bool isInv = false;
    public float invTimer = 1f;
    public int prevHealth;
    public TextMeshProUGUI sisHealthText;
    public float moveSpeed;

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
            //Destroy(gameObject);
        }
        if (health != prevHealth)
        {
            StartCoroutine(invincible());
        }
        float distP = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (transform.position != player.transform.position && distP > maxDist)
        {
           transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime); 
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

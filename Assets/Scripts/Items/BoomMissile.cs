using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class BoomMissile : MonoBehaviour
{
    public int damage;
    public GameObject damageNum;
    public float radius;
    public float boomRadius;
    public float knockBack;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(boomRadius, boomRadius, boomRadius);
        Destroy(gameObject, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            temp.z = 10;
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Destroy(num, 1f);
            collision.GetComponent<Enemy>().health -= damage;

            collision.GetComponent<Enemy>().knock = true;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce((collision.transform.position - transform.position) * knockBack, ForceMode2D.Impulse);
        }
    }
}

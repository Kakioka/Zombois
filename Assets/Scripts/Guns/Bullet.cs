using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitEffect;
    public GameObject damageNum;
    public float radius;
    public int damage;
    public int pierce = 0;
    public float knockBack;
    public float scale;

    private void Start()
    {
        gameObject.transform.localScale += new Vector3(scale,scale,scale);
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health - damage;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Destroy(num, 1f);
            rb.AddForce(gameObject.transform.up * knockBack, ForceMode2D.Impulse);
            if (pierce <= 0)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);
            }
            else
            {
                pierce--;
            }
        }
        else
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
    }
}
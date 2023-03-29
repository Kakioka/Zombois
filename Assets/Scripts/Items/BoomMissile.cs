using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.Rendering;

public class BoomMissile : MonoBehaviour
{
    public int damage;
    public GameObject damageNum;
    public float radius;
    public float boomRadius;
    public float knockBack;
    public bool bleedOn = false;
    public int bleedLvl;
    [SerializeField]
    private GameObject bleedPre;

    private void bleedEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 100);
        if (chanceBleed >= 65)
        {
            GameObject clone = Instantiate(bleedPre, collision.transform);
            clone.GetComponent<BleedEffect>().DoT *= (1 - (bleedLvl * 0.3f));
        }
    }

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

        if (collision.tag == "Enemy" || collision.gameObject.tag == "Shield" || collision.gameObject.tag == "Shopkeep")
        {
            if (bleedOn)
            {
                bleedEffect(collision);
            }

            collision.GetComponent<Enemy>().knock = true;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce((collision.transform.position - gameObject.transform.position) * knockBack, ForceMode2D.Impulse);

            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            temp.z = 10;
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Destroy(num, 1f);
            collision.GetComponent<Enemy>().health -= damage;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Enemy>().knock = true;
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((collision.transform.position - gameObject.transform.position) * knockBack, ForceMode2D.Impulse);
    }

}

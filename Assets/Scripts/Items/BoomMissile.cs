using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoomMissile : MonoBehaviour
{
    public int damage;
    public GameObject damageNum;
    public float radius;
    public float boomRadius;
    public float knockBack;
    public bool bleedOn = false;
    public int bleedLvl;
    public bool burnOn = false;
    public int burnLvl = 0;
    public bool freezeOn;
    public int freezeLvl;
    [SerializeField]
    private GameObject bleedPre;
    [SerializeField]
    private GameObject burnPre;
    [SerializeField]
    private GameObject freeze;
    [SerializeField]
    private GameObject hitEffect;

    public bool amBad;

    private void bleedEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 100);
        if (chanceBleed >= 65)
        {
            GameObject clone = Instantiate(bleedPre, collision.transform);
            clone.GetComponent<BleedEffect>().DoT *= (1 - (bleedLvl * 0.3f));
        }
    }

    private void burnEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 100);
        if (chanceBleed >= 65)
        {
            GameObject clone = Instantiate(burnPre, collision.transform);
            clone.GetComponent<BleedEffect>().time = clone.GetComponent<BleedEffect>().time * (1 + (0.3f * burnLvl));
        }
    }

    private void freezeEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 100);
        if (chanceBleed >= 65)
        {
            GameObject clone = Instantiate(freeze, collision.transform);
            freeze.GetComponent<BleedEffect>().time = clone.GetComponent<BleedEffect>().time * (1 + (0.2f * freezeLvl));
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
        if (!amBad)
        {
            if (collision.tag == "Enemy" || collision.gameObject.tag == "Shield" || collision.gameObject.tag == "Shopkeep")
            {
                if (bleedOn)
                {
                    bleedEffect(collision);
                }

                if (burnOn)
                {
                    burnEffect(collision);
                }

                collision.GetComponent<Enemy>().knock = true;
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce((collision.transform.position - gameObject.transform.position) * knockBack, ForceMode2D.Impulse);

                Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
                temp.z = 10;
                GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
                num.transform.position += new Vector3(0.25f, 0f);
                num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
                Destroy(num, 1f);
                collision.GetComponent<Enemy>().health -= damage;

                GameObject effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
                Destroy(effect, 1f);
            }
        }
        else
        {
            if (collision.tag == "Player" || collision.gameObject.tag == "Shield" || collision.gameObject.tag == "Shopkeep")
            {
                if (bleedOn)
                {
                    bleedEffect(collision);
                }

                if (burnOn)
                {
                    burnEffect(collision);
                }

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce((collision.transform.position - gameObject.transform.position) * knockBack, ForceMode2D.Impulse);

                Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
                temp.z = 10;
                GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
                num.transform.position += new Vector3(0.25f, 0f);
                num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
                Destroy(num, 1f);
                collision.GetComponent<Enemy>().health -= damage;

                GameObject effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
                Destroy(effect, 1f);
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Enemy>().knock = true;
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce((collision.transform.position - gameObject.transform.position) * knockBack, ForceMode2D.Impulse);
    }

}

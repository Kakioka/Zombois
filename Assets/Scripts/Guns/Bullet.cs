using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitEffect, damageNum;
    public float radius;
    public int damage;
    public int pierce = 0;
    public float knockBack, scale, force;
    public float life = 5f;

    public GameObject bleedPre;
    public bool bleedOn = false;
    public int bleedLvl;

    public bool splinterOn = false;
    public int splintLvl;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.localScale += new Vector3(scale, scale, scale);
        Destroy(gameObject, life);
    }

    private void bleedEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 100);
        if (chanceBleed > 70)
        {
            Instantiate(bleedPre, collision.transform);
        }
    }

    private void splinter(Collider2D collision)
    {
        for (int i = 0; i < 3 + splintLvl; i++)
        {
            Vector3 temp = (Random.insideUnitCircle.normalized * 0.7f) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            GameObject clone = Instantiate(gameObject, temp, Quaternion.identity);
            clone.GetComponent<Bullet>().life = 0.5f;
            clone.GetComponent<Bullet>().damage = Mathf.CeilToInt(damage * 0.3f);
            clone.GetComponent<Bullet>().splinterOn = false;
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            rb.AddForce((temp - collision.transform.position) * (force * 0.6f), ForceMode2D.Impulse);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health - damage;

            Rigidbody2D rbE = collision.gameObject.GetComponent<Rigidbody2D>();

            //spawn damage text
            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            temp.z = 10;
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Destroy(num, 1f);

            collision.gameObject.GetComponent<Enemy>().knock = true;
            //Vector2 direction = (Vector2)collision.transform.position - rb.position;
            //collision.transform = 

            rbE.AddForce(gameObject.transform.up * knockBack, ForceMode2D.Impulse);
            //rbE.velocity = gameObject.transform.up * knockBack;

            if (bleedOn)
            {
                bleedEffect(collision);
            }

            if (pierce <= 0)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                if (splinterOn)
                {
                    splinter(collision);
                }
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
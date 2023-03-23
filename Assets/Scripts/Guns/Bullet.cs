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
    [SerializeField]
    private GameObject fire;
    [SerializeField]
    private bool fireOn;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
        Destroy(gameObject, life);
    }

    private void bleedEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 100);
        if (chanceBleed >= 65)
        {
            GameObject clone = Instantiate(bleedPre, collision.transform);
            clone.GetComponent<BleedEffect>().DoT *= (1 - (bleedLvl * 0.3f)); 
        }
    }

    private void fireEffect(Collider2D collision) 
    {
        GameObject clone = Instantiate(fire, collision.transform);
    }

    private void splinter(Collider2D collision)
    {
        for (int i = 0; i < 2 + splintLvl; i++)
        {
            float rad = 0.8f * collision.gameObject.transform.localScale.y;
            Vector3 temp = (Random.insideUnitCircle.normalized * rad) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            Vector2 lookDir = (Vector2)temp - (Vector2)collision.transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            temp.z = 10;
            GameObject clone = Instantiate(gameObject, temp, Quaternion.identity);
            clone.GetComponent<Bullet>().life = 0.3f;
            clone.GetComponent<Bullet>().damage = Mathf.CeilToInt(damage * 0.3f);
            clone.GetComponent<Bullet>().splinterOn = false;
            clone.GetComponent<Rigidbody2D>().rotation = angle;
            clone.GetComponent<Bullet>().knockBack = 0;
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            float forceMod = 0.6f / collision.gameObject.transform.localScale.y;
            rb.AddForce((temp - collision.transform.position) * (force * forceMod), ForceMode2D.Impulse);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shield")
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

            if (fireOn) 
            {
                fireEffect(collision);
            }

            if (pierce <= 0)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                if (splinterOn && collision.gameObject.tag != "Shield")
                {
                    splinter(collision);
                }
                Destroy(effect, 1f);
                Destroy(gameObject);
            }
            else
            {
                if (collision.gameObject.tag == "Shield")
                {
                    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 1f);
                    Destroy(gameObject);
                }
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
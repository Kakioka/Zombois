using System.Collections;
using System.Collections.Generic;
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

    public bool burnOn;
    public int burnLvl;

    public bool freezeOn;
    public int freezeLvl;

    private Rigidbody2D rb;
    [SerializeField]
    private GameObject fire;
    public bool fireOn;
    [SerializeField]
    private bool trackingOn;
    [SerializeField]
    private GameObject explode;
    [SerializeField]
    private GameObject freeze;
    private float dist = 99999;
    private GameObject target;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private bool explodeOn;
    
    public float explodeScale;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
        if (explodeOn)
        {
            StartCoroutine(endLifeExplode());
        }
        else 
        {
            Destroy(gameObject, life);
        }
        //findTarget();
    }

    private IEnumerator endLifeExplode() 
    {
        yield return new WaitForSeconds(life);
        GameObject boomObj = Instantiate(explode, transform.position, Quaternion.identity);
        boomObj.GetComponent<BoomMissile>().damage = damage;
        boomObj.GetComponent<BoomMissile>().boomRadius = explodeScale;
        boomObj.GetComponent<BoomMissile>().knockBack = knockBack;
        Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        findTarget();
        if (target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * force;
        }
        else
        {
            rb.velocity = transform.up * force;
        }
    }

    void findTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject g in enemies)
        {
            float gDist = Vector2.Distance(transform.position, g.transform.position);
            if (gDist < dist)
            {
                dist = gDist;
                target = g;
            }
        }
    }

    private void bleedEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 101);
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

    private void burnEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 101);
        if (chanceBleed >= 65)
        {
            GameObject clone = Instantiate(fire, collision.transform);
            clone.GetComponent<BleedEffect>().time = clone.GetComponent<BleedEffect>().time * (1 + (0.3f * burnLvl));
        }
    }

    private void freezeEffect(Collider2D collision)
    {
        float chanceBleed = Random.Range(0, 101);
        if (chanceBleed >= 65)
        {
            GameObject clone = Instantiate(freeze, collision.transform);
            freeze.GetComponent<Freeze>().time = clone.GetComponent<Freeze>().time * (1 + (0.2f * freezeLvl));
        }
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
            clone.GetComponent<Bullet>().force = force * 0.3f;
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();
            float forceMod = 0.6f / collision.gameObject.transform.localScale.y;
            rb.AddForce((temp - collision.transform.position) * (force * forceMod), ForceMode2D.Impulse);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shield" || collision.gameObject.tag == "Shopkeep")
        {
            if (fireOn)
            {
                fireEffect(collision);
            }
           
            if (pierce <= 0)
            {
                if (splinterOn && collision.gameObject.tag != "Shield")
                {
                    splinter(collision);
                }

                if (explodeOn)
                {
                    GameObject boomObj = Instantiate(explode, transform.position, Quaternion.identity);
                    boomObj.GetComponent<BoomMissile>().damage = damage;
                    boomObj.GetComponent<BoomMissile>().boomRadius = explodeScale;
                    boomObj.GetComponent<BoomMissile>().knockBack = knockBack;
                    boomObj.GetComponent<BoomMissile>().bleedOn = bleedOn;
                    boomObj.GetComponent<BoomMissile>().bleedLvl = bleedLvl;
                    boomObj.GetComponent<BoomMissile>().burnOn = burnOn;
                    boomObj.GetComponent<BoomMissile>().burnLvl = burnLvl;
                    Destroy(gameObject);
                    return;
                }
                Destroy(gameObject);
            }
            else
            {
                if (collision.gameObject.tag == "Shield")
                {
                    Destroy(gameObject);
                    return;
                }
                pierce--;
            }

            if (bleedOn)
            {
                bleedEffect(collision);
            }

            if (burnOn)
            {
                burnEffect(collision);
            }

            if (freezeOn)
            {
                freezeEffect(collision);
            }

            GameObject effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(effect, 1f);

            collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health - damage;
            collision.gameObject.GetComponent<Enemy>().knock = true;
            Rigidbody2D rbE = collision.gameObject.GetComponent<Rigidbody2D>();
            rbE.AddForce(gameObject.transform.up * knockBack, ForceMode2D.Impulse);

            //spawn damage text
            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + (Vector2)collision.transform.position;
            temp.z = 10;
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.transform.position += new Vector3(0.25f, 0f);
            num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Destroy(num, 1f);

        }
        else
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
    }
}
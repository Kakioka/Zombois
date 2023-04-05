using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int laserLvl;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxLength;
    [SerializeField]
    private GameObject damageNum;
    [SerializeField]
    private float radius = 0.5f;
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject hitEffect;


    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(temp,2f);
        damage = 5 * laserLvl;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y >= maxLength)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localScale = new(transform.localScale.x, transform.localScale.y + Time.deltaTime * speed, transform.localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Shield" || collision.gameObject.tag == "Shopkeep")
        {
            GameObject effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(effect, 1f);

            collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health - damage;

            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + (Vector2)collision.transform.position;
            temp.z = 10;
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.transform.position += new Vector3(0.25f, 0f);
            num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Destroy(num, 1f);
        }

    }
}

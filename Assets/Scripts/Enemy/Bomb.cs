using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage = 1;
    public int knockBack = 1;
    [SerializeField]
    private int enemyDamage;

    [SerializeField]
    private GameObject damageNum;
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField] 
    private float radius;

    // Start is called before the first frame update
    

    
    void Start()
    {
        Destroy(gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().health = collision.gameObject.GetComponent<PlayerMovement>().health - damage;
        }

        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health = collision.gameObject.GetComponent<Enemy>().health - enemyDamage;
            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            temp.z = 10;
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.transform.position += new Vector3(0.25f, 0f);
            num.GetComponentInChildren<TextMeshProUGUI>().text = enemyDamage.ToString();
            Destroy(num, 1f);

            GameObject effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
            Destroy(effect, 1f);


        }

        if (collision.gameObject.tag == "Sister")
        {
            collision.gameObject.GetComponent<Sister>().health = collision.gameObject.GetComponent<Sister>().health - damage;
        }
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
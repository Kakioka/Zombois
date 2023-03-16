using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoomMissile : MonoBehaviour
{
    public int damage;
    public GameObject damageNum;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
}

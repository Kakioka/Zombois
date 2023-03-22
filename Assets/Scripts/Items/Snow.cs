using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Snow : MonoBehaviour
{

    public float speedMod;
    public float radius = 0.05f;
    public int damage;
    public float delay;
    public GameObject damageNum;

    private List<float> timers = new List<float>();
    private List<Collider2D> enemies = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < timers.Count; i++) 
        {
            timers[i] -= Time.deltaTime;
        }

        for (int i = 0; i < timers.Count; i++)
        {
            if (timers[i] <= 0) 
            {
                enemies[i].GetComponent<Enemy>().health -= damage;
                Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(enemies[i].transform.position.x, enemies[i].transform.position.y);
                temp.z = 10;
                GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
                num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
                Destroy(num, 1f);
                timers[i] = delay;
            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().moveSpeed *= speedMod;

            collision.GetComponent<Enemy>().health -= damage;
            Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(collision.transform.position.x, collision.transform.position.y);
            temp.z = 10;
            GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
            num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
            Destroy(num, 1f);

            timers.Add(delay);
            enemies.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().moveSpeed /= speedMod;
            timers.RemoveAt(enemies.IndexOf(collision));
            enemies.Remove(collision);
        }
    }
}

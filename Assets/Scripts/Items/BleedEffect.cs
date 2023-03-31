using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BleedEffect : MonoBehaviour
{
    public float time;
    public int damage;
    public float DoT;
    public float radius;

    public GameObject damageNum;

    private bool coolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    IEnumerator bleed()
    {
        coolDown = true;
        yield return new WaitForSeconds(DoT);
        GetComponentInParent<Enemy>().health -= damage;
        Vector3 temp = (Random.insideUnitCircle.normalized * radius) + new Vector2(transform.parent.position.x, transform.parent.position.y);
        temp.z = 10;
        GameObject num = Instantiate(damageNum, temp, damageNum.transform.rotation);
        num.transform.position += new Vector3(0.25f, 0f);
        num.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
        Destroy(num, 1f);
        
        coolDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown == false)
        {
            StartCoroutine(bleed());
        }
    }
}

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public GameObject gold;
    public GameObject copper;
    public GameObject silver;
    public GameObject player;
    public GameObject sister;
    public GameObject spawner;
    public float moveSpeed;
    public bool knock = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (health <= 0)
        {
            int random = Random.Range(0, 100);
            if (random >= 80)
            {
                GameObject coin = Instantiate(gold, transform.position, Quaternion.identity);
                coin.GetComponent<Coin>().player = player;
                coin.GetComponent<Coin>().sister = sister;
            }
            else if (random >= 70)
            {
                GameObject coin = Instantiate(silver, transform.position, Quaternion.identity);
                coin.GetComponent<Coin>().player = player;
                coin.GetComponent<Coin>().sister = sister;
            }
            else
            {
                GameObject coin = Instantiate(copper, transform.position, Quaternion.identity);
                coin.GetComponent<Coin>().player = player;
                coin.GetComponent<Coin>().sister = sister;
            }
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class Screamer : MonoBehaviour
{
    public float speedMod;
    public float spawnMod;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.GetComponent<Enemy>().spawner;
        spawner.GetComponent<Spawner>().time *= spawnMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().health <= 0)
        {
            spawner.GetComponent<Spawner>().time /= spawnMod;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().moveSpeed *= speedMod;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().moveSpeed /= speedMod;
        }
    }
}

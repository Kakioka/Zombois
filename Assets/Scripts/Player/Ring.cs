using UnityEngine;

public class Ring : MonoBehaviour
{
    public float knockBack = 1f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(collision.transform.position - player.transform.position * knockBack, ForceMode2D.Impulse);
        }
    }
}

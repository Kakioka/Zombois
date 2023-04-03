using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    public GameObject player;
    public GameObject sister;
    public int moveSpeed;
    public bool pickedUp = false;
    public bool pickedUpS = false;

    [SerializeField]
    private bool mag;
    [SerializeField]
    private bool armor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUpS)
        {
            Vector3 moveDir = (sister.transform.position - transform.position).normalized;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
        if (pickedUp)
        {
            Vector3 moveDir = (player.transform.position - transform.position).normalized;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Sister")
        {
            if (mag) 
            {
                foreach (GameObject g in GameObject.FindGameObjectsWithTag("Coin")) 
                {
                    g.GetComponent<Coin>().GetComponent<Coin>().pickedUp = true;
                }
            }
            if (armor)
            {
                if (player.GetComponent<PlayerMovement>().armor != 3)
                {
                    player.GetComponent<PlayerMovement>().armor++;
                }
                if (sister.GetComponent<Sister>().armor != 3)
                {
                    sister.GetComponent<Sister>().armor++;
                }
            }
            player.GetComponent<PlayerMovement>().bank += value;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PickUp")
        {
            pickedUp = true;
        }
        if (collision.gameObject.tag == "PickUpS")
        {
            pickedUpS = true;
        }
    }
}

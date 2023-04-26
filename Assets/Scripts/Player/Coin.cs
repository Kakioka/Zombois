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
    private GameObject explode;
    [SerializeField]
    private bool mag;
    [SerializeField]
    private bool armor;
    [SerializeField]
    private bool bomb;
    [SerializeField]
    private bool moon;

    [SerializeField]
    private AudioClip clip;


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

            if (bomb) 
            {
                GameObject temp = Instantiate(explode, collision.transform.position + new Vector3(0f,1.5f,0f), Quaternion.identity);
                temp.GetComponent<BoomMissile>().damage = 9999;
                temp.GetComponent<BoomMissile>().boomRadius = 12;
                Color c = temp.GetComponent<SpriteRenderer>().color;
                c.a = 0.5f;
                temp.GetComponent<SpriteRenderer>().color = c;
            }

            if (moon)
            {
                GameObject temp = GameObject.FindGameObjectWithTag("GameController");
                temp.GetComponent<PerkManager>().moonCoin++;
            }
            //gameObject.GetComponent<AudioSource>().pitch = Random.Range(.6f, 1.4f);
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            player.GetComponent<PlayerMovement>().bank += value;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PickUp" && !pickedUpS)
        {
            pickedUp = true;
        }
        if (collision.gameObject.tag == "PickUpS" && !pickedUp)
        {
            pickedUpS = true;
        }
    }
}

using UnityEngine;

public class sisBoss : MonoBehaviour
{
    public int currSpawns;
    public GameObject player;
    public GameObject sister;
    public GameObject spawner;
    public float hpMod;
    public float spawnSpeed = 3;
    public float spawnSpeedMod = 1;
    public GameObject shieldPref;
    public GameObject shield;
    public int iniShieldHp;
    public int shieldMod;
    public GameObject coinPre;

    private bool shieldOn = true;
    private int tempCurr;

    private void shieldSpawn()
    {
        shield = Instantiate(shieldPref);
        shield.GetComponent<targetFollow>().target = gameObject;
        //shield.GetComponent<Enemy>().coinPref = coinPre;
        shield.GetComponent<Enemy>().player = player;
        shield.GetComponent<Enemy>().sister = player;
        shield.GetComponent<Enemy>().health = iniShieldHp;
        shieldOn = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        shieldSpawn();
        spawner.GetComponent<Spawner>().player = player;
        spawner.GetComponent<Spawner>().sister = player;
        spawner.GetComponent<Spawner>().target = sister;
        spawner.GetComponent<Spawner>().hpMod = hpMod;
        spawner.GetComponent<Spawner>().time = spawnSpeed * spawnSpeedMod;
    }

    // Update is called once per frame
    void Update()
    {
        currSpawns = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (shield == null)
        {
            shieldOn = false;
        }
        if (currSpawns < tempCurr)
        {
            if (shieldOn == false)
            {
                shieldSpawn();
            }
            else
            {
                shield.GetComponent<Enemy>().health += shieldMod;
            }
            tempCurr--;
        }

        if (this.GetComponent<Enemy>().health == 0)
        {
            spawner.SetActive(false);
        }
        else if (spawner.GetComponent<Spawner>().coolDown == false)
        {
            tempCurr++;
            StartCoroutine(spawner.GetComponent<Spawner>().spawnRandom());
        }

    }
}
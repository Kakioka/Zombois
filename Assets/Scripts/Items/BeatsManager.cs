using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject note;
    [SerializeField]
    private GameObject spawn;
    [SerializeField]
    private GameObject end;

    private GameObject currNote;

    private float speedMod;

    public GameObject player;

    [SerializeField]
    private Gun gun;


    private bool noteSpawned = false;

    public int beatsLvl;
    public float timer;

    private bool damageUpped = false;

    void damageUp()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
        if ((timer > 0) && !damageUpped)
        {
            damageUpped = true;
            gun.damage = Mathf.CeilToInt(gun.damage * (1 + 0.3f));
        }
        else if ((timer <= 0) && damageUpped)
        {
            damageUpped = false;
            gun.damage = Mathf.FloorToInt(gun.damage / (1 + 0.3f));
            damageUpped = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = player.GetComponent<PlayerMovement>().gun;
        gun = temp.GetComponent<Gun>();
        GetComponentInChildren<targetFollow>().target = player;
        speedMod = 0.7f / (3 * gun.fireRate);
    }


    IEnumerator noteCoolDown()
    {
        noteSpawned = true;
        yield return new WaitForSeconds(0.3f);
        noteSpawned = false;
    }
    // Update is called once per frame

    void Update()
    {
        damageUp();
        if (currNote == null && !noteSpawned)
        {
            currNote = Instantiate(note, spawn.transform);
            currNote.GetComponent<Note>().gun = gun;
            currNote.GetComponent<Note>().beatsManager = this;
        }
        else
        {
            currNote.transform.position -=  new Vector3(0f,speedMod * Time.deltaTime);
            if (currNote.transform.position.y <= end.transform.position.y)
            {
                Destroy(currNote);
            }
        }
    }
}

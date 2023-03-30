using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public float time;

    private float moveO;

    private IEnumerator freeze() 
    {
        GetComponentInParent<Enemy>().moveSpeed = 0;
        yield return new WaitForSeconds(time);
        GetComponentInParent<Enemy>().moveSpeed = moveO;
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        moveO = GetComponentInParent<Enemy>().moveSpeed;
        StartCoroutine(freeze());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;

public class targetFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position + offset;
    }

    void FixedUpdate()
    {
        gameObject.transform.position = target.transform.position + offset;
    }
}

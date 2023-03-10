using UnityEngine;

public class sisHPFollow : MonoBehaviour
{
    public UIManager ui;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = ui.sister.transform.position + offset;
    }

    void FixedUpdate()
    {

    }
}

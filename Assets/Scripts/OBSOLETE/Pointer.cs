using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject sister;
    public GameObject UI;
    public GameObject gameM;
    public Rigidbody2D rb;
    public float borderSize;
    public float borderSizeS;
    public GameObject sisA;


    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        gameM = UI.GetComponent<UIManager>().gameManager;
        cam = gameM.GetComponent<gameManager>().cam;
        sister = UI.GetComponent<UIManager>().sister;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = cam.WorldToScreenPoint(sister.transform.position);
        Vector3 cap = target;
        Vector3 capS = target;
        if (cap.x <= borderSize) cap.x = borderSize;
        if(cap.x >= Screen.width) cap.x=Screen.width - borderSize;
        if (cap.y <= borderSize) cap.y = borderSize;
        if(cap.y>= Screen.height) cap.y=Screen.height - borderSize;

        if (capS.x <= borderSizeS) capS.x = borderSizeS;
        if (capS.x >= Screen.width) capS.x = Screen.width - borderSizeS;
        if (capS.y <= borderSizeS) capS.y = borderSizeS;
        if (capS.y >= Screen.height) capS.y = Screen.height - borderSizeS;

        Vector3 pointerPos = cam.ScreenToWorldPoint(cap);
        transform.position = pointerPos;
        sisA.transform.position = cam.ScreenToWorldPoint(capS);

    }

    void FixedUpdate()
    {
        Vector2 playerPos = sister.transform.position;
        Vector2 lookDir = playerPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}

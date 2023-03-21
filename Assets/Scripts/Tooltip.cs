using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Tooltip : MonoBehaviour
{
    public gameManager manager;
    [SerializeField]
    private TextMeshProUGUI tooltipText;
    [SerializeField]
    private RectTransform background;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        HideTooltip();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f;
        //transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        Vector3 target = Camera.main.WorldToScreenPoint(screenPoint);
        Vector3 cap = target;
        
        if (cap.x <= 0) cap.x = 0;
        if (cap.x >= Screen.width) cap.x = Screen.width - 0;
        if (cap.y <= 0) cap.y = 0;
        if (cap.y >= Screen.height) cap.y = Screen.height - 0;

        Vector3 pos = Camera.main.WorldToScreenPoint(cap);

        transform.position = pos;

        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void ShowTooltip() 
    {
        gameObject.SetActive(true);
        tooltipText.ForceMeshUpdate();
        Vector2 textSize = tooltipText.GetRenderedValues(false);
        Vector2 paddingSize = new Vector2(8, 8);
        background.sizeDelta = textSize + paddingSize;
    }

    public void HideTooltip() 
    {
        gameObject.SetActive(false);
    }
}

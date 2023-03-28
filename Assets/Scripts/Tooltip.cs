using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
        Vector3 target = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 cap = target;
        if (cap.x + background.rect.width >= Screen.width) 
        {
            cap.x = Screen.width - background.rect.width;
        }
        if (cap.y + background.rect.height >= Screen.height)
        {
            cap.y = Screen.height - background.rect.height;
        }
        transform.position = Camera.main.ScreenToWorldPoint(cap);
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

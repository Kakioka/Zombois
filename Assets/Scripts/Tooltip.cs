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
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        Vector2 anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
        if(anchoredPosition.x + background.rect.width > manager.currUI.GetComponentInChildren<RectTransform>().rect.width) 
        {
            anchoredPosition.x =  manager.currUI.GetComponentInChildren<RectTransform>().rect.width - background.rect.width;
        }
        transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
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

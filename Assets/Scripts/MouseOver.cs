using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    [SerializeField]
    private Tooltip toolTip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        toolTip.ShowTooltip();
    }

    private void OnMouseExit()
    {
        toolTip.HideTooltip();
    }
}

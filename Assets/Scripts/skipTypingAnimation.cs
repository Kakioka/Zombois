using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipTypingAnimation : MonoBehaviour
{
    private int stage = 0;
    public float closeTime;

    private void Start()
    {
        
    }

    private IEnumerator close()
    {
        yield return new WaitForSeconds(closeTime);
        GameObject parent = this.transform.parent.gameObject;
        Destroy(parent);
    }

    private void Update()
    {

            if (GetComponent<typewriterUI>()._tmpProText.text == GetComponent<typewriterUI>().writer)
            {
                stage = 1;
                StartCoroutine(close());
            }
    }

    public void OnClick()
    {
        if (stage == 1)
        {
            GameObject parent = this.transform.parent.gameObject;
            Destroy(parent);
        }
        if (stage == 0)
        {
            Debug.Log("Button clicked"); // Debug statement
            GetComponent<typewriterUI>().skipTypingAnimation = true;
            stage++;
        }
    }
}


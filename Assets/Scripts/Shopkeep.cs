using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shopkeep : MonoBehaviour
{
    [SerializeField]
    private GameObject shopM;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject back;
    [SerializeField]
    private List<string> listText = new List<string>();
    [SerializeField]
    private float time;

    private GameObject currText;

    [SerializeField]
    private int counter = 0;
    [SerializeField]
    private int textCounter = 0;

    Coroutine last = null;

    IEnumerator shopText() 
    {
        Debug.Log("shop");
        back.SetActive(true);
        currText = Instantiate(text, transform);
        currText.GetComponent<TextMeshPro>().text = listText[textCounter];
        for (float timer = time;  timer >= 0; timer -= Time.deltaTime) 
        {
            yield return null;  
        } 
        Destroy(currText);
        back.SetActive(false);
    }

    IEnumerator kickOut() 
    {
        Debug.Log("kick");
        back.SetActive(true);
        currText = Instantiate(text, transform);
        currText.GetComponent<TextMeshPro>().text = listText[textCounter];
        for (float timer = time; timer >= 0; timer -= Time.deltaTime)
        {
            yield return null;
        }
        Destroy(currText);
        back.SetActive(false);
        shopM.GetComponent<upgradeShopManager>().nextButton();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter >= 3) 
        {
            if (textCounter == 5)
            {
                if (currText == null)
                {
                    last = StartCoroutine(kickOut());
                    textCounter++;
                }
                else
                {
                    Destroy(currText);
                    StopCoroutine(last);
                    last = StartCoroutine(kickOut());
                    textCounter++;
                }
            }
            else 
            {
                if (currText == null)
                {
                    last = StartCoroutine(shopText());
                    textCounter++;
                }
                else
                {
                    StopCoroutine(last);
                    Destroy(currText);
                    last = StartCoroutine(shopText());
                    textCounter++;
                }
            }
            counter = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (textCounter <= 5) 
            {
                counter++;
            }
        }
    }
}

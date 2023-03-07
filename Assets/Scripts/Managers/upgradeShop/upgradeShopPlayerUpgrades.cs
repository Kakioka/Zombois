using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class upgradeShopPlayerUpgrades : MonoBehaviour
{

    public GameObject gameManager;

    public int pickUpI;
    public int pickUpII;
    public int pickUpIII;

    public int moveSpeedI;
    public int moveSpeedII;
    public int moveSpeedIII;

    public TextMeshProUGUI pickUpText;
    public TextMeshProUGUI moveSpeedText;

    public GameObject pickUpButton;
    public GameObject moveSpeedButton;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<upgradeShopManager>().gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        playerText();
    }

    void playerText()
    {
        switch (gameManager.GetComponent<gameManager>().moveUp)
        {
            case 0:
                moveSpeedText.text = "Move Speed Level I";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedI;
                break;
            case 1:
                moveSpeedText.text = "Move Speed Level II";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedII;
                break;
            case 2:
                moveSpeedText.text = "Move Speed Level III";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedIII;
                break;
            case 3:
                moveSpeedText.text = "Move Speed Level Maxed";
                moveSpeedButton.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().rangeUp)
        {
            case 0:
                pickUpText.text = "Pick Up Range Level I";
                pickUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pickUpI;
                break;
            case 1:
                pickUpText.text = "Pick Up Range Level II";
                pickUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pickUpII;
                break;
            case 2:
                pickUpText.text = "Pick Up Range Level III";
                pickUpButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + pickUpIII;
                break;
            case 3:
                pickUpText.text = "Pick Up Range Maxed";
                pickUpButton.SetActive(false);
                break;
        }
    }

    public void rangeButton()
    {
        switch (gameManager.GetComponent<gameManager>().rangeUp)
        {
            case 0:
                if (gameManager.GetComponent<gameManager>().bank >= pickUpI)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 1;
                    gameManager.GetComponent<gameManager>().bank -= pickUpI;
                }
                break;
            case 1:
                if (gameManager.GetComponent<gameManager>().bank >= pickUpII)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 2;
                    gameManager.GetComponent<gameManager>().bank -= pickUpII;
                }
                break;
            case 2:
                if (gameManager.GetComponent<gameManager>().bank >= pickUpIII)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 3;
                    gameManager.GetComponent<gameManager>().bank -= pickUpIII;
                }
                break;
        }
    }

    public void playerSpeedButton()
    {
        switch (gameManager.GetComponent<gameManager>().moveUp)
        {
            case 0:
                if (gameManager.GetComponent<gameManager>().bank >= moveSpeedI)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 1;
                    gameManager.GetComponent<gameManager>().bank -= moveSpeedI;
                }
                break;
            case 1:
                if (gameManager.GetComponent<gameManager>().bank >= moveSpeedII)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 2;
                    gameManager.GetComponent<gameManager>().bank -= moveSpeedII;
                }
                break;
            case 2:
                if (gameManager.GetComponent<gameManager>().bank >= moveSpeedIII)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 3;
                    gameManager.GetComponent<gameManager>().bank -= moveSpeedIII;
                }
                break;
        }
    }
}

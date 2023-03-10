using TMPro;
using UnityEngine;

public class upgradeShopPlayerUpgrades : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject player;

    public int pickUpI;
    public int pickUpII;
    public int pickUpIII;

    public int moveSpeedI;
    public int moveSpeedII;
    public int moveSpeedIII;

    public TextMeshProUGUI pickUpText;
    public TextMeshProUGUI moveSpeedText;
    public TextMeshProUGUI sisMoveSpeedText;

    public GameObject pickUpButton;
    public GameObject moveSpeedButton;
    public GameObject sisMoveSpeedButton;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<upgradeShopManager>().gameManager;
        player = gameObject.GetComponent<upgradeShopManager>().player;
    }

    // Update is called once per frame
    void Update()
    {
        playerText();
    }

    void playerText()
    {
        switch (gameManager.GetComponent<gameManager>().sisMoveUp)
        {
            case 0:
                sisMoveSpeedText.text = "Sister Move Speed Level I";
                sisMoveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedI;
                break;
            case 1:
                sisMoveSpeedText.text = "Sister Move Speed Level II";
                sisMoveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedII;
                break;
            case 2:
                sisMoveSpeedText.text = "Sister Move Speed Level III";
                sisMoveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedIII;
                break;
            case 3:
                sisMoveSpeedText.text = "Sister Move Speed Level Maxed";
                sisMoveSpeedButton.SetActive(false);
                break;
        }

        switch (gameManager.GetComponent<gameManager>().moveUp)
        {
            case 0:
                moveSpeedText.text = "Player Move Speed Level I";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedI;
                break;
            case 1:
                moveSpeedText.text = "Player Move Speed Level II";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedII;
                break;
            case 2:
                moveSpeedText.text = "Player Move Speed Level III";
                moveSpeedButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + moveSpeedIII;
                break;
            case 3:
                moveSpeedText.text = "Player Move Speed Level Maxed";
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
                if (player.GetComponent<PlayerMovement>().bank >= pickUpI)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= pickUpI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= pickUpII)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= pickUpII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= pickUpIII)
                {
                    gameManager.GetComponent<gameManager>().rangeUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= pickUpIII;
                }
                break;
        }
    }

    public void playerSpeedButton()
    {
        switch (gameManager.GetComponent<gameManager>().moveUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= moveSpeedI)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= moveSpeedI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= moveSpeedII)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= moveSpeedII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= moveSpeedIII)
                {
                    gameManager.GetComponent<gameManager>().moveUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= moveSpeedIII;
                }
                break;
        }
    }

    public void sisterSpeedButton()
    {
        switch (gameManager.GetComponent<gameManager>().sisMoveUp)
        {
            case 0:
                if (player.GetComponent<PlayerMovement>().bank >= moveSpeedI)
                {
                    gameManager.GetComponent<gameManager>().sisMoveUp = 1;
                    player.GetComponent<PlayerMovement>().bank -= moveSpeedI;
                }
                break;
            case 1:
                if (player.GetComponent<PlayerMovement>().bank >= moveSpeedII)
                {
                    gameManager.GetComponent<gameManager>().sisMoveUp = 2;
                    player.GetComponent<PlayerMovement>().bank -= moveSpeedII;
                }
                break;
            case 2:
                if (player.GetComponent<PlayerMovement>().bank >= moveSpeedIII)
                {
                    gameManager.GetComponent<gameManager>().sisMoveUp = 3;
                    player.GetComponent<PlayerMovement>().bank -= moveSpeedIII;
                }
                break;
        }
    }
}

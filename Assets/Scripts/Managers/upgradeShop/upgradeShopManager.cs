using TMPro;
using UnityEngine;

public class upgradeShopManager : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject player;
    public GameObject sister;

    public GameObject UI;

    public GameObject sisHPButton;
    public GameObject playerHPButton;
    public int vaccineCost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hpVal();
    }

    void hpVal()
    {
        if (gameManager.GetComponent<gameManager>().playerH == 3)
        {
            playerHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "HP Max";
        }
        else
        {
            playerHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + vaccineCost;
        }

        if (gameManager.GetComponent<gameManager>().sisH == 3)
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "HP Max";
        }
        else
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + vaccineCost;
        }
    }

    public void sisButton()
    {
        if (gameManager.GetComponent<gameManager>().sisH != 3)
        {
            if (player.GetComponent<PlayerMovement>().bank >= vaccineCost)
            {
                player.GetComponent<PlayerMovement>().bank -= vaccineCost;
                gameManager.GetComponent<gameManager>().sisH++;
                sister.GetComponent<Sister>().health++;
            }
        }
    }

    public void playerButton()
    {
        if (gameManager.GetComponent<gameManager>().playerH != 3)
        {
            if (player.GetComponent<PlayerMovement>().bank >= vaccineCost)
            {
                player.GetComponent<PlayerMovement>().bank -= vaccineCost;
                gameManager.GetComponent<gameManager>().playerH++;
                player.GetComponent<PlayerMovement>().health++;
            }
        }
    }

    public void nextButton()
    {
        gameManager.GetComponent<gameManager>().bank = player.GetComponent<PlayerMovement>().bank;
        gameManager.GetComponent<gameManager>().spawnLevel(gameManager.GetComponent<gameManager>().levelNum);
    }
}

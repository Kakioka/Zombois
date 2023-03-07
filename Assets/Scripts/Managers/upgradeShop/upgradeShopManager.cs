using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class upgradeShopManager : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject player;
    public GameObject sister;

    public GameObject UI;

    public GameObject sisHPButton;
    public TextMeshProUGUI sisHPVal;

    public TextMeshProUGUI playerHPVal;
    public GameObject playerHPButton;

    public int vaccineCost;
    public TextMeshProUGUI vaccineCostText;

    // Start is called before the first frame update
    void Start()
    {
        vaccineCostText.text = vaccineCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hpVal();
    }

    void hpVal() 
    {
        playerHPVal.text = gameManager.GetComponent<gameManager>().playerH.ToString();
        sisHPVal.text = gameManager.GetComponent<gameManager>().sisH.ToString();

        if (gameManager.GetComponent<gameManager>().playerH == 3)
        {
            playerHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "HP Max";
        }
        else 
        {
            playerHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }

        if (gameManager.GetComponent<gameManager>().sisH == 3)
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "HP Max";
        }
        else 
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
        }
    }

    public void sisButton()
    {
        if (gameManager.GetComponent<gameManager>().sisH != 3)
        {
            if (gameManager.GetComponent<gameManager>().bank >= vaccineCost)
            {
                gameManager.GetComponent<gameManager>().bank -= vaccineCost;
                gameManager.GetComponent<gameManager>().sisH++;
                sister.GetComponent<Sister>().health++;
            }
        }
    }

    public void playerButton()
    {
        if (gameManager.GetComponent<gameManager>().playerH != 3)
        {
            if (gameManager.GetComponent<gameManager>().bank >= vaccineCost)
            {
                gameManager.GetComponent<gameManager>().bank -= vaccineCost;
                gameManager.GetComponent<gameManager>().playerH++;
                player.GetComponent<PlayerMovement>().health++;
            }
        }
    }

    public void nextButton()
    {
        gameManager.GetComponent<gameManager>().spawnLevel(gameManager.GetComponent<gameManager>().levelNum);
    }
}

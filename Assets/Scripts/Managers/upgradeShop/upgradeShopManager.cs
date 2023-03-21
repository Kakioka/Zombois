using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class upgradeShopManager : MonoBehaviour
{
    public GameObject gameManager;

    public GameObject player;
    public GameObject sister;

    public GameObject UI;

    [SerializeField] 
    private GameObject sisHPButton;
    [SerializeField]
    private GameObject playerHPButton;
    [SerializeField]
    private int vaccineCost;
    [SerializeField]
    private GameObject dead;


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

        if (gameManager.GetComponent<gameManager>().sisH == sister.GetComponent<Sister>().maxHealth)
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "HP Max";
        }
        else
        {
            sisHPButton.GetComponentInChildren<TextMeshProUGUI>().text = "Cost: " + vaccineCost;
        }

        if (sister.GetComponent<Sister>().health <= 0) 
        {
            Time.timeScale = 0;
            dead.SetActive(true);
        }
    }

    public void sisButton()
    {
        if (gameManager.GetComponent<gameManager>().sisH != sister.GetComponent<Sister>().maxHealth)
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

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }
}

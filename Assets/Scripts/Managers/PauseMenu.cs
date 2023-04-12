using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    [SerializeField]
    private GameObject OptionsMenu;
    [SerializeField]
    private GameObject OptionsB;
    [SerializeField]
    private GameObject MenuB;
    [SerializeField]
    private GameObject ExitB;
    [SerializeField]
    private GameObject ResumeB;


    //Update is called once per fram
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                OptionsMenu.SetActive(false);
                OptionsB.SetActive(true);
                ExitB.SetActive(true);
                MenuB.SetActive(true);
                ResumeB.SetActive(true);
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {

        Debug.Log("Loading menu...");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {

        Debug.Log("Quitting game...");
        Application.Quit();

    }

}

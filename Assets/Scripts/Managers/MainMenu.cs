using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject volumeSlider;

    public void Start()
    {
        Time.timeScale = 1;
        if (volumeSlider != null)
        {
            volumeSlider.GetComponent<Slider>().value = 1f;
        }
    }
        

    public void PlayGame()
    {
        //uses the scene manager to load a scene by index
        //gets the index of the current active scene and adds 1 to it so the index of the next scene is loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        
    }

    public void volume()
    {
        AudioListener.volume = volumeSlider.GetComponent<Slider>().value;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

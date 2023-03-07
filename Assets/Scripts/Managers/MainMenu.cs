using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void PlayGame(){
        //uses the scene manager to load a scene by index
        //gets the index of the current active scene and adds 1 to it so the index of the next scene is loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }

}

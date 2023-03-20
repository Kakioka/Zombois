using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        //uses the scene manager to load a scene by index
        //gets the index of the current active scene and adds 1 to it so the index of the next scene is loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Easy() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Hard() 
    {
        SceneManager.LoadScene(11);
    }

    public void Hell() 
    {
        SceneManager.LoadScene(12);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}

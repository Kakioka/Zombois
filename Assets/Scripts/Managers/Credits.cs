using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    //redirects to mainMenu or build index 0
    public void goToMM()
    {
        SceneManager.LoadScene(0);
    }

}

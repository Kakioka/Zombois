using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject volumeSlider;
    public GameObject networkM;
    public Toggle fullscreenTog, vsyncTog;
    public TMP_Dropdown resDrop;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex;

    private Resolution resolution;
    private float currVol;

    public void Start()
    {
        Time.timeScale = 1;

        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();
        resDrop.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++) 
        {
            if (resolutions[i].refreshRate == currentRefreshRate) 
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++) 
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height) 
            {
                currentResolutionIndex= i;
            }
        }

        resDrop.AddOptions(options);
        resDrop.value= currentResolutionIndex;
        resDrop.RefreshShownValue();

        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        if (volumeSlider != null)
        {
            volumeSlider.GetComponent<Slider>().value = 1f;
        }
        volumeSlider.GetComponent<Slider>().value = AudioListener.volume;
    }


    public void PlayGame()
    {
        //uses the scene manager to load a scene by index
        //gets the index of the current active scene and adds 1 to it so the index of the next scene is loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(networkM);
    }

    private void Update()
    {

    }
    public void setRes(int resolutionIntdex) 
    {
        resolution = filteredResolutions[resolutionIntdex];
    }
    

    public void ApplyGraphics() 
    {
        Screen.SetResolution(resolution.width, resolution.height, true);
        Screen.fullScreen = fullscreenTog.isOn;
        AudioListener.volume = currVol;
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else 
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void volume()
    {
       currVol = volumeSlider.GetComponent<Slider>().value;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void credits()
    {
        SceneManager.LoadScene(15);
    }

}

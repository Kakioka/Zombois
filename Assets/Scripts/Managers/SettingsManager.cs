using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    [SerializeField]
    private float volume;

    private void Awake()
    {
        if(Instance == null) 
        {
            SceneManager.sceneUnloaded += OnSceneUnloaded;
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += levelLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= levelLoaded;
    }

    void levelLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioListener.volume = volume;
    }

    void OnSceneUnloaded(Scene current) 
    {
        volume = AudioListener.volume;
    }
}

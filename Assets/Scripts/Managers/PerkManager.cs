using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerkManager : MonoBehaviour
{
    public int moonCoin;
    public static PerkManager Instance;

    private GameObject gameM;

    public List<bool> perkOwned = new List<bool>();

    public List<bool> perkEquiped = new List<bool>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        if (scene.name == "Stage1" || scene.name == "Stage1Hard" || scene.name == "Stage1Hell" || scene.name == "Stage1Normal")
        {
            gameM = GameObject.FindGameObjectWithTag("gameM");
        }

        if (gameM != null)
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientManager : NetworkBehaviour
{

    public NetworkObject player;
    public RuntimeAnimatorController sis;

    // Start is called before the first frame update
    void Start()
    {
        player = NetworkManager.LocalClient.PlayerObject;
        DontDestroyOnLoad(this.gameObject);
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
        if (scene.name == "MultiplayerTest")
        {
            
        }


        if (scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }
}

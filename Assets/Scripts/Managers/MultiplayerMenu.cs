using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using TMPro;
using System.Net;
using System.Net.Sockets;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.SceneManagement;

public class MultiplayerMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField ip;

    [SerializeField] string ipAddress;
    public UnityTransport transport;

    void Start()
    {
        ipAddress = "0.0.0.0";
        SetIpAddress(); // Set the Ip to the above address
    }

    // To Host a game
    public void StartHost()
    {
        SceneManager.LoadScene(10);
    }

    // To Join a game
    public void StartClient()
    {
        ipAddress = ip.text;
        SetIpAddress();
        NetworkManager.Singleton.StartClient();
    }

    /* Sets the Ip Address of the Connection Data in Unity Transport
	to the Ip Address which was input in the Input Field */
    // ONLY FOR CLIENT SIDE
    public void SetIpAddress()
    {
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ipAddress;
    }
}

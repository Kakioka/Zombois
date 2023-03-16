using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using Unity.Netcode;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Unity.Netcode.Transports.UTP;
using TMPro;
using UnityEditorInternal;
using UnityEditor.Animations;
using Mono.Cecil.Cil;

public class LobbyManager : NetworkBehaviour
{
    [SerializeField] TextMeshProUGUI ipAddressText;
    [SerializeField] string ipAddress;
    [SerializeField] UnityTransport transport;
    public GameObject player;
    public GameObject player2;
    public GameObject[] list;

    // Start is called before the first frame update
    void Start()
    {
        ipAddress = "0.0.0.0";
        SetIpAddress(); // Set the Ip to the above address
        GetLocalIPAddress();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                ipAddressText.text = ip.ToString();
                ipAddress = ip.ToString();
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }

    public void SetIpAddress()
    {
        transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ipAddress;
    }
}

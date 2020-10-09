using Assets.Networking;
using Networking;
using UnityEngine;

public class Network : MonoBehaviourNetworkingCallbacks
{
    
    void Start()
    {
        MainNetwork.Connect("Smile");
    }

    override public void OnServerConnected()
    {
        Debug.Log("123");

        MainNetwork.CreateRoom("123123", 5);

        MainNetwork.ListRooms();
    }

    void OnApplicationQuit()
    {
        MainNetwork.Disconnect();
    }

    void Update()
    {
        
    }
}

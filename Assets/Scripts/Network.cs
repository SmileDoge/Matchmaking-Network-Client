using NativeWebSocket;
using UnityEngine;

public class Network : MonoBehaviour
{
    private WebSocket _socket;
    
    async void Start()
    {
        _socket = new WebSocket("ws://localhost:7000");

        _socket.OnOpen += () =>
        {
            Debug.Log("Connected");
        };

        await _socket.Connect();
    }
    
    void Update()
    {
        
    }
}

using Assets.Networking;
using Networking.Packets;
using System;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using WebSocketSharp;

namespace Networking
{
    class MainNetwork
    {

        public delegate void PacketHandler(Packet packet);

        public Room Room { get; private set;}
        public static int ID { get; private set; }

        private static Dictionary<int, PacketHandler> _packetHandlers = new Dictionary<int, PacketHandler>();

        private static List<IServerCallbacks> serverCallbacks = new List<IServerCallbacks>();
        private static WebSocket _websocket;

        public static void Connect(string nickname)
        {

            if(nickname == null) { nickname = "Player " + UnityEngine.Random.Range(1, 9999); }
            //nickname = nickname.Substring(1, 20);
           
            InitializePackets();

            ID = 0;

            _websocket = new WebSocket("ws://localhost:7000/?nickname=" + HttpUtility.UrlEncode(nickname));

            _websocket.OnMessage += HandleMessage;

            _websocket.OnError += HandleError;

            _websocket.OnOpen += HandleConnect;

            _websocket.OnClose += HandleDisconnect;
            
            _websocket.Connect();
        }

        public static void Disconnect()
        {
            if(_websocket.ReadyState == WebSocketState.Open)
            {
                _websocket.Close();
            }
        }

        public static void RegisterCallback(MonoBehaviourNetworkingCallbacks obj)
        {
           if (obj is IServerCallbacks)
           {
                serverCallbacks.Add(obj);
           }
        }
        public static void UnRegisterCallback(MonoBehaviourNetworkingCallbacks obj)
        {
            if(obj is IServerCallbacks)
            {
                serverCallbacks.Remove(obj);
            }
        }
        public static void CreateRoom(string roomName, int maxPlayers)
        {
            maxPlayers = Mathf.Clamp(maxPlayers, 1, 10);
            //roomName = roomName.Substring(1, 20);

            ClientSend.CreateRoom(roomName, maxPlayers);
        }
        public static void ListRooms()
        {
            ClientSend.ListRoom();
        }
        public static void SendPacket(Packet packet)
        {
            _websocket.Send(packet.ToArray());
        }
        public static void SetID(int id) 
        {
            if(ID != 0)
            {
                ID = id;
            }
        }
        
        private static void HandleConnect(object sender, EventArgs ev)
        {
            foreach (var obj in serverCallbacks)
            {
                obj.OnServerConnected();
            }
        }
        private static void HandleDisconnect(object sender, CloseEventArgs ev)
        {
            foreach (var obj in serverCallbacks)
            {
                obj.OnServerDisconnected(ev);
            }
        }
        private static void HandleError(object sender, ErrorEventArgs ev)
        {
            foreach (var obj in serverCallbacks)
            {
                obj.OnServerError(ev);
            }
        }
        private static void HandleMessage(object sender, MessageEventArgs ev)
        {
            if (ev.IsBinary)
            {
                ThreadManager.ExecuteOnMainThread(() =>
                {
                    using (var packet = new Packet(ev.RawData))
                    {
                        var packet_id = packet.ReadInt();
                        if (_packetHandlers.TryGetValue(packet_id, out PacketHandler value))
                        {
                            value(packet);
                        }
                    }
                });
            }
        }
        
        private static void InitializePackets()
        {
            _packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)PacketEnum.SERVER_JOIN_ROOM, ClientHandle.JoinRoom},
                { (int)PacketEnum.SERVER_ROOM_ERROR, ClientHandle.RoomError},
                { (int)PacketEnum.SERVER_LEAVE_ROOM, ClientHandle.LeaveRoom},
                { (int)PacketEnum.SERVER_LIST_ROOM, ClientHandle.ListRoom},
                { (int)PacketEnum.SERVER_EVENT, ClientHandle.Event},
                { (int)PacketEnum.SERVER_CONNECT, ClientHandle.Connect},
                { (int)PacketEnum.SERVER_DISCONNECT, ClientHandle.Disconnect},
            };
        }
    }
}

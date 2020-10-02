using NativeWebSocket;
using Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    class MainNetwork
    {

        public delegate void PacketHandler(Packet packet);

        private static WebSocket _websocket;
        private static Dictionary<int, PacketHandler> _packetHandlers = new Dictionary<int, PacketHandler>();

        public static async void Connect(string url)
        {
            _websocket = new WebSocket(url);

            InitializePackets();

            _websocket.OnMessage += HandleMessage;

            await _websocket.Connect();
        }

        private static void InitializePackets()
        {
            _packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)PacketEnum.SERVER_JOIN_ROOM, ClientHandle.JoinRoom},
                { (int)PacketEnum.SERVER_LEAVE_ROOM, ClientHandle.LeaveRoom},
                { (int)PacketEnum.SERVER_LIST_ROOM, ClientHandle.ListRoom},
                { (int)PacketEnum.SERVER_EVENT, ClientHandle.Event},
                { (int)PacketEnum.SERVER_CONNECT, ClientHandle.Connect},
                { (int)PacketEnum.SERVER_DISCONNECT, ClientHandle.Disconnect},
            };
        }

        private static void HandleMessage(byte[] data)
        {
            using ( var packet = new Packet(data) )
            {
                var packet_id = packet.ReadInt();
                if ( _packetHandlers.TryGetValue(packet_id, out PacketHandler value))
                {
                    value(packet);
                }
            }
        }
    }
}

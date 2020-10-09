using Networking;
using Networking.Packets;

namespace Assets.Networking
{
    class ClientSend
    {
        public static void CreateRoom(string roomName, int maxPlayers)
        {
            using (Packet packet = new Packet((int)PacketEnum.CLIENT_CREATE_ROOM))
            {
                packet.Write(maxPlayers);
                packet.Write(roomName);
                MainNetwork.SendPacket(packet);
            }
        }

        public static void ListRoom()
        {
            using (Packet packet = new Packet((int)PacketEnum.CLIENT_LIST_ROOM))
            {
                MainNetwork.SendPacket(packet);
            }
        }
    }
}

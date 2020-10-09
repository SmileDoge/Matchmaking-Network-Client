using Assets.Networking;
using Networking.Packets;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    class ClientHandle
    {
        public static void JoinRoom(Packet packet)
        {

        }

        public static void RoomError(Packet packet)
        {
            string roomName = packet.ReadString();
            RoomErrorEnum type = (RoomErrorEnum)packet.ReadInt();
            switch (type)
            {
                case RoomErrorEnum.roomMaxPlayers:
                    Debug.Log("Maximum players in room");
                    break;

                case RoomErrorEnum.roomAlreadyJoined:
                    Debug.Log("Already joined to room");
                    break;

                case RoomErrorEnum.roomNotFound:
                    Debug.Log("This room not found");
                    break;

                case RoomErrorEnum.roomAlreadyUsedName:
                    Debug.Log($"Room with name ({roomName}) already created");
                    break;

                default:
                    break;

            }
        }

        public static void LeaveRoom(Packet packet)
        {

        }

        public static void ListRoom(Packet packet)
        {
            int roomsCount = packet.ReadInt();
            Debug.Log("Rooms count: " + roomsCount);
            for (int i = 0; i < roomsCount; i++)
            {
                Debug.Log("Room " + i);
                string roomName = packet.ReadString();
                int userCount = packet.ReadInt();
                int maxPlayers = packet.ReadInt();
                string hostNickname = packet.ReadString();
                Debug.Log($"Room Name: {roomName}");
                Debug.Log($"Users Count: {userCount}");
                Debug.Log($"Max Players: {maxPlayers}");
                Debug.Log($"Nickname Host: {hostNickname}");
                Debug.Log("-----");
                
            }
        }

        public static void Event(Packet packet)
        {

        }

        public static void Connect(Packet packet)
        {
            int id = packet.ReadInt();
            MainNetwork.SetID(id);
        }

        public static void Disconnect(Packet packet)
        {

        }
    }
}

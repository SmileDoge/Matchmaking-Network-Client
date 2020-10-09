using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Networking
{
    enum RoomErrorEnum
    {
        roomNotFound,
        roomMaxPlayers,
        roomAlreadyJoined,
        roomAlreadyUsedName,

        roomJoined,
    }

    class Room
    {
        public Player Host { get; private set; }
        public string RoomName { get; private set; }
        public int MaxPlayers { get; private set; }
        public List<Player> Users { get; private set; }

        public Room(string roomName, Player host, int maxPlayers)
        {
            RoomName = roomName;
            Host = host;
            Users = new List<Player>();
            MaxPlayers = maxPlayers;
        }
    }
}

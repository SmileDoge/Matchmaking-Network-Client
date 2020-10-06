using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Networking
{
    class Room
    {
        public Player Host { get; private set; }
        public string RoomName { get; private set; }
        public int MaxPlayers { get; private set; }
        public List<Player> Users { get; set; }

        public Room(string roomName, Player host, int maxPlayers)
        {
            RoomName = roomName;
            Host = host;
            Users = new List<Player>();
            MaxPlayers = maxPlayers;
        }
    }
}

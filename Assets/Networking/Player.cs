using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Networking
{
    class Player
    {
        public int UserID { get; private set; }
        public string Nickname { get; private set; }
        public Room Room { get; private set; }
        public bool IsMe { get; private set; }
        public Player()
        {

        }
    }
}

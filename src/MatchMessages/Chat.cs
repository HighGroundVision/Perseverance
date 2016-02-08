using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
    public class Chat : GameMessage
    {
        public string player { get; set; }
        public string said { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
    public class BarracksKill : GameMessage
    {
        public int barracks { get; set; }
        public int player { get; set; }

    }
}

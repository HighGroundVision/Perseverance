using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
    public class RunePickup : GameMessage
    {
        public int player { get; set; }
        public int rune { get; set; }
    }
}

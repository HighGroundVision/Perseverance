using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HGV.Perserverance.MatchMessages
{
    public class KillRoshan : GameMessage
    {
        public int team { get; set; }
        public int value { get; set; }
    }
}
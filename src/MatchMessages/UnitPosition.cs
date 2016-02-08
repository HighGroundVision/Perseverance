using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
    public class UnitPosition : GameMessage
    {
        public int hero { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//type\":3,\"time\":\"%s\",\"hero\":%d,\"healing\":%d,\"stuns\":%d,\"buyback\":%d,\"lasthits\":%d,\"denies\":%d,\"misses\":%d,\"nearby_creeps\":%d,\"gold_creeps\":%d,\"gold_heroes\":%d,
//\"gold_income\":%d,\"gold_reliable\":%d,\"gold_unreliable\":%d,\"gold_shared\":%d,\"gold\":%d,\"xp\":%d

namespace HGV.Perserverance.MatchMessages
{
    public class UnitEconomy : GameMessage
    {

        public int hero { get; set; }
        public int healing { get; set; }
        public int stuns { get; set; }
        public int buyback { get; set; }
        public int lasthits { get; set; }
        public int denies { get; set; }
        public int misses { get; set; }
        public int nearby_creeps { get; set; }
        public int gold_creeps { get; set; }
        public int gold_heroes { get; set; }
        public int gold_income { get; set; }
        public int gold_reliable { get; set; }
        public int gold_unreliable { get; set; }
        public int gold_shared { get; set; }
        public int gold { get; set; }
        public int xp { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
{\"type\":25,\"time\":\"%s\",\"iat\":%t,\"iah\":%t,\"iti\":%t,\"ith\":%t,\"ivr\":%t,\"ivd\":%t,\"itb\":%t,\"attacker\":\"%s\",
\"target\":\"%s\",\"target_source\":\"%s\",\"damage_source\":\"%s\",\"inflictor\":\"%s\",\"value\":%d},"

*/
namespace HGV.Perserverance.MatchMessages
{
    public class Heal : GameMessage
    {

        public bool iat { get; set; } // GetIsAttackerIllusion
		public bool iah { get; set; } // GetIsAttackerHero
		public bool iti { get; set; } // GetIsTargetIllusion
		public bool ith { get; set; } // GetIsTargetHero
		public bool ivr { get; set; } // GetIsVisibleRadiant
		public bool ivd { get; set; } // GetIsVisibleDire
		public bool itb { get; set; } // GetIsTargetBuilding
		public string attacker { get; set; }
        public string target { get; set; }
        public string targetSource { get; set; }
        public string damageSource { get; set; }
        public string inflictor { get; set; }
        public int value { get; set; }
    }
}

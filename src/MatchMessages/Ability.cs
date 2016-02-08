using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
{\"type\":27,\"time\":\"%s\",\"iat\":%t,\"iah\":%t,\"ivr\":%t,\"ivd\":%t,\"attacker\":\"%s\",\"inflictor\":\"%s\",\"ability_level\":%d}
    */
namespace HGV.Perserverance.MatchMessages
{
    public class Ability : GameMessage
    {
        public DateTime iat { get; set; }
        public DateTime iah { get; set; }
        public DateTime ivr { get; set; }
        public DateTime ivd { get; set; }
        public string attacker { get; set; }
        public string inflictor { get; set; }
        public int ability_level { get; set; }
    }
}

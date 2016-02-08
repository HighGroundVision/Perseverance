using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
"{\"type\":26,\"time\":\"%s\",\"iat\":%t,\"iah\":%t,\"iti\":%t,\"ith\":%t,\"ivr\":%t,\"ivd\":%t,\"itb\":%t,\"attacker\":\"%s\",
\"target\":\"%s\",\"target_source\":\"%s\",\"damage_source\":\"%s\"}
    */
namespace HGV.Perserverance.MatchMessages
{
    public class Death : GameMessage
    {

        public DateTime iat { get; set; }
        public DateTime iah { get; set; }
        public DateTime iti { get; set; }
        public DateTime ith { get; set; }
        public DateTime ivr { get; set; }
        public DateTime ivd { get; set; }
        public DateTime itb { get; set; }
        public string attacker { get; set; }
        public string target { get; set; }
        public string targetSource { get; set; }
        public string damageSource { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
{\"type\":31,\"time\":\"%s\",\"target\":\"%s\",\"targetsource\":\"%s\",\"reason\":%d,\"amount\":%d
*/

namespace HGV.Perserverance.MatchMessages
{
    public class Gold : GameMessage
    {

        public string target { get; set; }
        public string targetsource { get; set; }
        public int reason { get; set; }
        public int amount { get; set; }
    }
}

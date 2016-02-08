using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
"{\"type\":32,\"time\":\"%s\",\"target\":\"%s\",\"reason\":%d,\"amount\":%d},"
    */
namespace HGV.Perserverance.MatchMessages
{
    public class XP : GameMessage
    {

        public string target { get; set; }
        public int reason { get; set; }
        public int amount { get; set; }
    }
}
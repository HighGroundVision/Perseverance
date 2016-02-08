using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
"{\"type\":33,\"time\":\"%s\",\"target\":\"%s\",\"value\":%d}
    */
namespace HGV.Perserverance.MatchMessages
{
    public class BuildingKill : GameMessage
    {

        public string target { get; set; }
        public int value { get; set; }
    }
}
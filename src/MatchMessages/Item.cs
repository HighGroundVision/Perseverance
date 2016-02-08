using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
{\"type\":28,\"time\":\"%s\",\"player\":\"%s\",\"item\":\"%s\",\"level\":%d},
    */

namespace HGV.Perserverance.MatchMessages
{
    public class Item : GameMessage
    {

        public string player { get; set; }
        public string item { get; set; }
        public int level { get; set; }
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
{\"type\":34,\"time\":\"%s\",\"attacker\":\"%s\",\"target\":\"%s\",\"target_source\":\"%s\",\"value\":%d},"
    */
namespace HGV.Perserverance.MatchMessages
{
    public class MultiKill : GameMessage
    {

        public string attacker { get; set; }
        public string target { get; set; }
        public string targetSource { get; set; }
        public int value { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
    public class TowerDeny : GameMessage
    {
        public int tower { get; set; }
        public int player { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
{\"type\":29,\"time\":\"%s\",\"player\":\"%s\",\"item\":\"%s\"}
    */
namespace HGV.Perserverance.MatchMessages
{
    public class Purchase : GameMessage
    {

        public string player { get; set; }
        public string item { get; set; }
    }
}
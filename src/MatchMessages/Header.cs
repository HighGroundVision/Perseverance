using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
	public class Header : BaseMessage
	{
		public int version { get; set; }
		public DateTime date { get; set; }
	}
}

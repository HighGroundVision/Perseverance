using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
	public class UnitSummary : GameMessage
	{
		public int hero { get; set; }
		public int level { get; set; }
		public int kills { get; set; }
		public int deaths { get; set; }
		public int assists { get; set; }
	}
}

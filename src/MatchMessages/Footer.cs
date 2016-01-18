using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
	public class Footer : BaseMessage
	{
		public TimeSpan elapsed { get; set; }
		public TimeSpan pregame_start { get; set; }
		public TimeSpan game_start { get; set; }
		public TimeSpan game_end { get; set; }
	}
}

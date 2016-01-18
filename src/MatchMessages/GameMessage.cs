using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
	public abstract class GameMessage : BaseMessage
	{
		public TimeSpan time { get; set; }
	}
}

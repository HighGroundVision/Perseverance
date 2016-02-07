using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Perserverance.Tests
{
	public class MatchEventHanlderTest
	{
		[Fact]
		public async Task GetEvents()
		{
			using (var handler = await MatchEventHanlder.GetHandler())
			{
				var data = await handler.DownloadReplay(2115905708);
				var json = await handler.ParseReplay(data);
				var events = await handler.GetEventsFromReplay(json);
			}
		}
	}
}

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
			var handler = new MatchEventHanlder();
			var events = await handler.GetEvents(2115905708);

			Assert.NotEmpty(events);
		}
	}
}

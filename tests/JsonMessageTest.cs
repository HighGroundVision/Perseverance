using HGV.Perserverance.MatchMessages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HGV.Perserverance.Tests
{
	public class JsonMessageTest
	{
		[Fact]
		public void DeserializationOfInheretedTypes()
		{
			var json = new StringBuilder();
			json.Append("[{\"type\":0,\"version\":2,\"date\":\"2015-11-02 22:22:00\"},");
			json.Append("{\"type\":2,\"time\":\"00:01:41\",\"hero\":97,\"level\":0,\"kills\":0,\"deaths\":0,\"assists\":0},");
			json.Append("{\"type\":3,\"time\":\"00:01:41\",\"hero\":97,\"level\":0,\"kills\":0,\"deaths\":0,\"assists\":0},");
			json.Append("{\"type\":1,\"elapsed\":\"00:00:33\",\"pregame_start\":\"00:02:37\",\"game_start\":\"00:03:52\",\"game_end\":\"00:53:38\"}]");
			
			//"elapsed":33.6398947s,"pregame_start":2m37s,"game_start":3m52s,"game_end":53m38s

			var items = JsonConvert.DeserializeObject<List<BaseMessage>>(json.ToString(), new GameMessageConverter());

			Assert.NotEmpty(items);

			var filtered = items.OfType<Footer>().ToList();

			Assert.Equal(1, filtered.Count);
		}

	}
}

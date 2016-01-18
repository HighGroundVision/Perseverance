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
			var json = "[{\"type\":0,\"version\":2,\"date\":\"2015-11-02\"},{\"type\":2,\"time\":\"00:01:41\",\"hero\":97,\"level\":0,\"kills\":0,\"deaths\":0,\"assists\":0},{\"type\":1,\"elapsed\":\"00:00:33\",\"pregame_start\":\"00:02:37\",\"game_start\":\"00:03:52\",\"game_end\":\"00:53:38\"}]";
			var items = JsonConvert.DeserializeObject<List<BaseMessage>>(json,	new GameMessageConverter());

			Assert.Equal(3, items.Count);

			

		}

	}
}

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
			var storageService = new MatchStorageService();

			using (var handler = await MatchReplayHanlder.GetHandler())
			{
				ulong matchId = 2115905708;

				var data = await handler.DownloadReplay(matchId);
				await storageService.StoreRawReplay(matchId, data);

				var json = await handler.ParseReplay(data);
				await storageService.StoreParsedReplay(matchId, json);

				var events = await handler.GetEventsFromReplay(json);
			}
		}
	}
}

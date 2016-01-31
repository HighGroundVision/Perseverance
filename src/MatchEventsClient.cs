using HGV.Crystalys;
using HGV.Radiance;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance
{
	public class MatchEventsClient
	{

		public async Task<List<object>> GetEvent(long id)
		{

			throw new NotImplementedException();

			/* 1. get match replay
			   2. call mango giving the replay getting list of events
			   3. Run the event stream through analyzers to create match specific details
			   4. Return the details
			*/

			var mangoUrl = ConfigurationManager.AppSettings["Mango.Url"].ToString();

			var service = new SteamUserService();
			var userInfo = await service.GetNextAvailable();

			using (var webClient = new WebClient())
			using (var dotaClient = new DotaGameClient(userInfo.Username, userInfo.Password, userInfo.Sentry))
			{
				dotaClient.Connect(TimeSpan.FromMinutes(1));

				var replayData = dotaClient.DownloadReplay(id, TimeSpan.FromMinutes(1));

				var bjson = webClient.UploadData(mangoUrl, replayData);
				var json = Convert.ToBase64String(bjson);
			}
		}

	}
}

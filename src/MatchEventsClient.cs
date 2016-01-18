using HGV.Crystalys;
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

			var mangoUrl = ConfigurationManager.AppSettings["UrlToMango"].ToString();
			var username = ConfigurationManager.AppSettings["DotaGameClientUserName"].ToString();
			var password = ConfigurationManager.AppSettings["DotaGameClientPassword"].ToString();
			var timeout = int.Parse(ConfigurationManager.AppSettings["DotaGameClientDownloadReplayTimeout"].ToString());

			using (var webClient = new WebClient())
			using (var dotaClient = new DotaGameClient(username, password, null))
			{
				dotaClient.Connect();

				var replayData = dotaClient.DownloadReplay(id, TimeSpan.FromMinutes(timeout));

				var bjson = webClient.UploadData(mangoUrl, replayData);
				var json = Convert.ToBase64String(bjson);


			}


		}

	}
}

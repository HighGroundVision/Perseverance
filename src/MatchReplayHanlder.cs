using HGV.Crystalys;
using HGV.Perserverance.MatchMessages;
using HGV.Radiance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance
{
	public sealed class MatchReplayHanlder : IDisposable
	{
		private const string MANGO_URL_KEY = "Mango.Url";

		private DotaGameClient DotaClient { get; set; }

		private MatchReplayHanlder()
		{
		}

		public static async Task<MatchReplayHanlder> GetHandler()
		{
			var handler = new MatchReplayHanlder();
			await handler.Connect();
			return handler;
		}

		private async Task Connect()
		{
			var userService = new SteamUserService();
			SteamUser userInfo = null;

			try
			{	
				userInfo = await userService.GetNextAvailable();

				this.DotaClient = new DotaGameClient(userInfo.Username, userInfo.Password, userInfo.Sentry);

				await this.DotaClient.Connect();
			}
			catch (Exception)
			{
				if(userInfo != null)
					await userService.Trip(userInfo.Id);

				throw;
			}
		}

		public void Dispose()
		{
			if(this.DotaClient != null)
			{
				this.DotaClient.Dispose();
				this.DotaClient = null;
			}
		}

		public async Task<byte[]> DownloadReplay(ulong id)
		{
			var replayData = await this.DotaClient.DownloadReplay(id);
			if (replayData == null)
				throw new ArgumentNullException(nameof(replayData));

			return replayData;
		}

		public async Task<string> ParseReplay(byte[] data)
		{
			string json = null;
			using (var client = new HttpClient())
			{
				var mangoUrl = ConfigurationManager.AppSettings[MANGO_URL_KEY].ToString();
				var reponse = await client.PostAsync(mangoUrl, new ByteArrayContent(data));
				json = await reponse.Content.ReadAsStringAsync();
			}

			if (json == null)
				throw new ArgumentNullException(nameof(json));

			return json;
		}

		public async Task<List<BaseMessage>> GetEventsFromReplay(string json)
		{
			return await Task.Run<List<BaseMessage>>(() => {
				var items = JsonConvert.DeserializeObject<List<BaseMessage>>(json, new GameMessageConverter());
				if (items == null)
					throw new ArgumentNullException(nameof(items));

				if (items.Count == 0)
					throw new ArgumentOutOfRangeException(nameof(items));

				var header = items.OfType<Header>().FirstOrDefault();
				if (header == null)
					throw new ArgumentNullException(nameof(header));

				var footer = items.OfType<Footer>().FirstOrDefault();
				if (footer == null)
					throw new ArgumentNullException(nameof(footer));

				foreach (var item in items.OfType<GameMessage>())
					item.time = item.time.Subtract(footer.game_start);

				return items;
			});
		}
	}
}
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
	public class MatchEventHanlder
	{

		public async Task<List<BaseMessage>> GetEvents(long id)
		{
			var userService = new SteamUserService();
			var userInfo = await userService.GetNextAvailable();

			byte[] replayData = null;
			using (var client = new DotaGameClient(userInfo.Username, userInfo.Password, userInfo.Sentry))
			{
				client.OnConnected += (o, e) => {
					if (e.Result)
						Trace.TraceInformation("Connected to Steam, Logging in '{0}'", userInfo.Username);
					else
						throw new ApplicationException("Unable to connect to Steam");
						//Trace.TraceError("Unable to connect to Steam");
				};
				client.OnDisconnected += (o, e) => {
					e.Reconnect = true;

					Trace.TraceInformation("Disconnected from Steam.");
				};
				client.OnLoggedOn += (o, e) => {
					if (e.Sucess)
						Trace.TraceInformation("Successfully logged on!");
					else
						throw new ApplicationException(string.Format("Unable to logon to Steam: {0}", e.Result));
						//Trace.TraceError("Unable to logon to Steam: {0}", e.Result);
				};
				client.OnAccountLogonDenied += (o, e) => {
					//Trace.TraceInformation("Regenerate Sentry File Hash for {0}.", userInfo.Username);
					userService.Trip(userInfo.Id);
					throw new ApplicationException("Tripped Account Logon Denied");
				};
				client.OnClientWelcome += (o, e) => {
					Trace.TraceInformation("Connected to GC. Version: {0}", e.Message.version);
				};

				client.Connect();

				replayData = client.DownloadReplay(id);
			}

			if (replayData == null)
				throw new ArgumentNullException(nameof(replayData));

			string json = null;
			using (var client = new HttpClient())
			{
				var mangoUrl = ConfigurationManager.AppSettings["Mango.Url"].ToString();
				var reponse = await client.PostAsync(mangoUrl, new ByteArrayContent(replayData));
				json = await reponse.Content.ReadAsStringAsync();
			}

			if (json == null)
				throw new ArgumentNullException(nameof(json));

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
		}
	}
}
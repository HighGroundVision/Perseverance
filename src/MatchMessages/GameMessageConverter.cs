using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGV.Perserverance.MatchMessages
{
	public class GameMessageConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(BaseMessage).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject item = JObject.Load(reader);
			
			var type = item["type"].Value<int>();
			switch (type)
			{
				case 0:
					return item.ToObject<Header>();
				case 1:
					return item.ToObject<Footer>();
				case 2:
					return item.ToObject<UnitSummary>();
				case 3:
					return item.ToObject<UnitEconomy>();
				case 4:
					return item.ToObject<UnitPosition>();
				case 5:
					return item.ToObject<WardObserver>();
				case 6:
					return item.ToObject<WardSentry>();
				case 7:
					return item.ToObject<Chat>();
				case 8:
					return item.ToObject<BarracksKill>();
				case 9:
					return item.ToObject<TowerKill>();
				case 10:
					return item.ToObject<TowerDeny>();
				case 11:
					return item.ToObject<EffegyKill>();
				case 12:
					return item.ToObject<FirstBlood>();
				case 13:
					return item.ToObject<KillRoshan>();
				case 14:
					return item.ToObject<AegisTaken>();
				case 15:
					return item.ToObject<AegisStolen>();
				case 16:
					return item.ToObject<AegisDenied>();
				case 17:
					return item.ToObject<CourierLost>();
				case 18:
					return item.ToObject<CourierRespawned>();
				case 19:
					return item.ToObject<Glyphed>();
				case 20:
					return item.ToObject<RunePickup>();
				case 21:
					return item.ToObject<RuneBottle>();
				case 22:
					return item.ToObject<Glyphed>();
				case 23:
					return item.ToObject<Prediciton>();
				case 24:
					return item.ToObject<Damage>();
				case 25:
					return item.ToObject<Heal>();
				case 26:
					return item.ToObject<Death>();
				case 27:
					return item.ToObject<Ability>();
				case 28:
					return item.ToObject<Item>();
				case 29:
					return item.ToObject<Purchase>();
				case 30:
					return item.ToObject<BuyBack>();
				case 31:
					return item.ToObject<Gold>();
				case 32:
					return item.ToObject<XP>();
				case 33:
					return item.ToObject<BuildingKill>();
				case 34:
					return item.ToObject<MultiKill>();
				case 35:
					return item.ToObject<KillStreak>();
				default:
					return new UnknownTypeMessage() { type = type, data = item.ToString() };
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
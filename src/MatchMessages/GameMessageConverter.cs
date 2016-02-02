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

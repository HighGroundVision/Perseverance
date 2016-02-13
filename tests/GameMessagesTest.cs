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
    public class GameMessagesTest
    {
        [Fact]
        public void MessageType1()
        {
            var json = new StringBuilder();
            json.Append("[{\"type\":0,\"version\":2,\"date\":\"2015-11-02 22:22:00\"}]");

            var items = JsonConvert.DeserializeObject<List<BaseMessage>>(json.ToString(), new GameMessageConverter());
            Assert.NotEmpty(items);

            var filtered = items.OfType<Header>().ToList();
            Assert.NotEmpty(filtered);

            var item = filtered.FirstOrDefault();
            Assert.NotNull(item);

            Assert.Equal(new DateTime(2015, 11, 02, 22, 22, 00), item.date);
            Assert.Equal(0, item.type);
            Assert.Equal(2, item.version);
            
        }

        [Fact]
        public void MessageType2()
        {        
            var json = new StringBuilder();
            json.Append("[{\"type\":1,\"elapsed\":\"00:00:30\",\"pregame_start\":\"00:01:00\",\"game_start\":\"01:00:00\",\"game_end\":\"01:21:02\"}]");

            var items = JsonConvert.DeserializeObject<List<BaseMessage>>(json.ToString(), new GameMessageConverter());
            Assert.NotEmpty(items);

            var filtered = items.OfType<Footer>().ToList();
            Assert.NotEmpty(filtered);

            var item = filtered.FirstOrDefault();
            Assert.NotNull(item);

            Assert.Equal(TimeSpan.FromSeconds(30), item.elapsed);
            Assert.Equal(TimeSpan.FromMinutes(1), item.pregame_start);
            Assert.Equal(TimeSpan.FromHours(1), item.game_start);
            Assert.Equal(new TimeSpan(1,21,2), item.game_end);
        }

    }
}

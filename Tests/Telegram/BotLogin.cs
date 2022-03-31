using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Telegram.Bot;

namespace Tests.Telegram
{
    public class BotLogin
    {
        [Test]
        public void Test()
        {
            var content = File.ReadAllText("./Telegram/token.json");
            var obj = JsonConvert.DeserializeObject<JObject>(content);
            var token = obj.GetValue("token").ToString();

            var bot = new TelegramBotClient(token);
            Assert.IsNotNull(bot.BotId);
        }
    }
}
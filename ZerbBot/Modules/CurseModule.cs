
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ZerbBot.Modules
{
    [Group("Curse")]
    public class CurseModule : ModuleBase<SocketCommandContext>
    {

        public String getInsult()
        {
            string json = File.ReadAllText("resources/insults.json");
            dynamic insults = JsonConvert.DeserializeObject(json);
            Random rand = new Random();
            int index = rand.Next(0, 183);
            return insults[index];
        }

        [Command]
        public async Task Diss()
        {
            await ReplyAsync(getInsult());
        }
        [Command("user")]
        public async Task DissUser(SocketGuildUser user)
        {

            var dmChannel = await user.GetOrCreateDMChannelAsync();
            await dmChannel.SendMessageAsync(getInsult());
        }
    }
}

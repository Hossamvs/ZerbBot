using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace ZerbBot.Modules
{
    [Group("Curse")]
    public class CurseModule : ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task Diss()
        {
            string[] dissList = new string[] { "Fuck you", "Faggot", "Drink piss and die " };
            Random random = new Random();
            string diss = dissList[random.Next(0, dissList.Length)];
            await ReplyAsync(diss);
        }
        [Command("user")]
        public async Task DissUser(SocketGuildUser user)
        {

            var dmChannel = await user.GetOrCreateDMChannelAsync();

            string[] dissList = new string[] { "Fuck you", "Faggot", "Drink piss and die", "No one likes you","I hope you get aids" };
            Random random = new Random();
            string diss = dissList[random.Next(0, dissList.Length)];

            await dmChannel.SendMessageAsync(diss);
        }
    }
}

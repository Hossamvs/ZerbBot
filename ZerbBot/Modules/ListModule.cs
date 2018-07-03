using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace ZerbBot.Modules
{

    public class ListModule : ModuleBase<SocketCommandContext>
    {
        public async Task DissUser(SocketGuildUser user)
        {

            var dmChannel = await user.GetOrCreateDMChannelAsync();           

            //await dmChannel.SendMessageAsync();
        }
    }
}

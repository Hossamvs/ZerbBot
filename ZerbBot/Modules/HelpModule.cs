using System.Threading.Tasks;
using Discord.Commands;
using Discord;

namespace ZerbBot.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task CommandList()
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Command List");
            embed.WithDescription("!cat\n!dog\n!meme\n!curse\n!curse user @user\n!echo\n!choose choice1|choice2\n!purge int");
            await Context.Channel.SendMessageAsync("", false, embed);
        }
    }
} 

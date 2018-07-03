using Discord.Commands;
using Discord;
using System;
using System.Threading.Tasks;


namespace ZerbBot.Modules
{
    public class CatModule : ModuleBase<SocketCommandContext>
    {

        //private readonly HttpClient _http = new HttpClient();
        
        [Command("cat")]
        public async Task CatAsync()
        {
            
            var embed = new EmbedBuilder();
            embed.WithTitle("Cat Picture");
            //embed.WithImageUrl("https://cataas.com/cat");
            Random rand = new Random();
            int cat = rand.Next(70000000, 100000000);
            embed.WithImageUrl("http://thecatapi.com/api/images/get?"+cat);

            await Context.Channel.SendMessageAsync("", false, embed);



        }

    }
}

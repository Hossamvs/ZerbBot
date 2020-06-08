using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using System.Net;
using Newtonsoft.Json;

namespace ZerbBot.Modules
{
    public class DogModule : ModuleBase<SocketCommandContext>

    {
        [Command("dog")]
        public async Task DogAsync()
        {

            string json = "";
            //initialize a webclient to interact with the internet
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://dog.ceo/api/breeds/image/random");
            }
            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);
            string dogpicture = dataObject.message.ToString();


            var embed = new EmbedBuilder();
            embed.WithTitle("Dog Picture");
            embed.WithImageUrl(dogpicture);
            await Context.Channel.SendMessageAsync("", false, embed);



        }
    }
}

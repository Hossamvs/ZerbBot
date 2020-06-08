using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ZerbBot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {
        #region echo
        [Command("echo")]
        public async Task Echo([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Echoed Message");
            embed.WithDescription(message);
            embed.WithColor(new Color(255, 0, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
        #endregion


        #region hello
        [Command("hello")]
        public async Task Hello()
        {
            await  Context.Channel.SendMessageAsync("Hello " + Context.User.Username);
            //await ReplyAsync("tizi");
        }
        #endregion


        #region Choose
        [Command("choose")]
        public async Task Choose([Remainder]string message)
        {
            //Splitting the message into segments and choosing one randomly 
            string[] options = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Random random = new Random();
            string selection = options[random.Next(0, options.Length)];

            //sending the selected message in an embed
            var embed = new EmbedBuilder();
            embed.WithTitle("Choice is");
            embed.WithDescription(selection);
            embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("", false, embed);
        }
        #endregion


        #region Purge
        [Command("purge"),RequireUserPermission(GuildPermission.Administrator),RequireBotPermission(GuildPermission.Administrator)]
        public async Task Purge(uint amount)
        {
            var messages = await Context.Channel.GetMessagesAsync(((int)amount + 1)).Flatten();
            await Context.Channel.DeleteMessagesAsync(messages);                                  
        }
        #endregion



        #region RandomMeme
        [Command("meme")]
        public async Task MemeGenerate()
        {
            string json = "";
            //initialize a webclient to interact with the internet
            using (WebClient client = new WebClient())
            {
                json = client.DownloadString("https://api.imgflip.com/get_memes");
            }
            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);

            //get random meme 
            Random random = new Random();
            int number = random.Next(0, 101);
            string meme = dataObject.data.memes[number].url.ToString();

            //embed meme and send it
            var embed = new EmbedBuilder();
            embed.WithTitle("Generated Meme");
            embed.WithColor(0, 255, 0);
            embed.WithImageUrl(meme);
            await Context.Channel.SendMessageAsync("", false, embed);
        }
        #endregion

        [Command("kosomak")]
        public async Task Kosomak()
        {
            await Context.Channel.SendMessageAsync("Kosomeen omak");

        }
    }

}


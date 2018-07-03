using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Reflection;

namespace ZerbBot
{
    //Everything is Asynchronous because that is how discord works

    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _serivce;

        public async Task InitializeAsync(DiscordSocketClient client)
        {
            _client = client;
            _serivce = new CommandService();
            await _serivce.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;

        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var message = s as SocketUserMessage;
            if (message == null)
                return;
            var context = new SocketCommandContext(_client, message);
            int argPos = 0; //gets rid of the prefix as in decides when the prefix ends and the command begins
            if(message.HasStringPrefix(Config.bot.cmdPrefix, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos)) //Handles if bot is mentioned or command is called
            {
                var result = await _serivce.ExecuteAsync(context, argPos);
                if(!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}

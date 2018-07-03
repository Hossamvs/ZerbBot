using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Discord.Commands;
using ZerbBot.Services;
using System.Net.Http;
using ZerbBot.Modules;

namespace ZerbBot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        private IServiceProvider _services;


        static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult(); //because discord works asynchronously so we have to adapt main method

        public async Task StartAsync()
        {

            if (Config.bot.token == String.Empty || Config.bot.token == null)
                return;

            _client = new DiscordSocketClient(new DiscordSocketConfig  //debugging
            {
                LogLevel = Discord.LogSeverity.Verbose
            });

            _client.Log +=  Log;

            //_services = ConfigureServices();

            //login
            await _client.LoginAsync(Discord.TokenType.Bot, Config.bot.token);  // Tokens should be considered secret data, and never hard-coded.

            await _client.StartAsync();

            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);

            // Block the program until it is closed.
            await Task.Delay(-1);
        }

        private async Task Log(Discord.LogMessage message)
        {
            Console.WriteLine(message.Message);           
        }

        /*private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandler>()
                .AddSingleton<HttpClient>()
                .AddSingleton<CatModule>()     
                .AddSingleton<AudioService>()
                .AddSingleton<AudioModule>()
                .BuildServiceProvider();

        }*/
    }
}

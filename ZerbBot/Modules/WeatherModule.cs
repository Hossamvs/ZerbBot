using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using System.Net;
using Newtonsoft.Json;

namespace ZerbBot.Modules
{
    public class WeatherModule : ModuleBase<SocketCommandContext>
    {


        [Command("forecast")]
        public async Task GetWeatherAsync(string city,string country)
        {
            string json = "";

            using (WebClient client = new WebClient())
            {              
                json = client.DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid=829da16af1f03077991ab4714b2da85b&units=metric");
            }

            var dataObject = JsonConvert.DeserializeObject<dynamic>(json);
            string icon = dataObject.weather[0].icon.ToString();
            string desc = dataObject.weather[0].description.ToString();
            string temperature = dataObject.main.temp.ToString();
            string Minimumtemperature = dataObject.main.temp_min.ToString();
            string Maximumtemperature = dataObject.main.temp_max.ToString();
            string humidity = dataObject.main.humidity.ToString();
            string Pressure = dataObject.main.pressure.ToString();
            string windspeed = dataObject.wind.speed.ToString();
            string winddegree = dataObject.wind.deg.ToString();
            

            var embed = new EmbedBuilder();
            embed.WithTitle("Forecast");
            embed.WithDescription($"`{desc}`");
            embed.WithThumbnailUrl($"http://openweathermap.org/img/w/{icon}.png");
            embed.AddField("Temperature", temperature + "°C");
            embed.AddInlineField("Minimum Temperature", Minimumtemperature + "°C");
            embed.AddInlineField("Maximum Temperature", Maximumtemperature + "°C");
            embed.AddInlineField("Wind speed", windspeed+" km/h");
            embed.AddInlineField("Wind degree", winddegree + "°");
            embed.AddInlineField("Humidity",humidity+"%");
            embed.AddInlineField("Pressure",Pressure);
            await Context.Channel.SendMessageAsync("", false, embed);



        }
    }
}

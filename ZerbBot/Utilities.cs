using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;


namespace ZerbBot
{
    class Utilities
    {
        //Dictionary to interact with JSON file
        private static Dictionary<string, string> alerts;
        //private static Dictionary<string, string> memes;
        //Constructor
        static Utilities()
        {
            string json = File.ReadAllText("SystemLang/alerts.json");
            //string memejson = File.ReadAllText("Resources/meme.json");

            var data = JsonConvert.DeserializeObject <dynamic>(json);
            //var memedata = JsonConvert.DeserializeObject<dynamic>(memejson);

            alerts = data.ToObject<Dictionary<string, string>>();
            //memes = data.ToObject<Dictionary<string, string>>();

        }

        //Returns value if key is found inside dictionary
        public static string GetAlert(string key)
        {           
            if (alerts.ContainsKey(key))
                return alerts[key];

            return "";
        }
        
        /*public static string GetMeme(string key)
        {
            if (memes.ContainsKey(key))
                return memes[key];

            return "";
        }*/

        public static string GetFormattedAlert(string key, object parameter)
        {
            if (alerts.ContainsKey(key))
                return String.Format(alerts[key], parameter);

            return "";
        }
    }
}
